using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace vibrance.GUI.common
{
    public partial class VibranceGUI : Form
    {
        private const string AppName = "vibranceGUI";
        private const string TwitterLink = "https://twitter.com/juvlarN";
        private const string SefinekWebsite = "https:/sefinek.net";
        private const string GitHubRepo = "https://github.com/sefinek24/vibranceGUI";

        private const string PaypalDonationLink = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=JDQFNKNNEW356";

        private readonly int _defaultIngameValue;
        private readonly int _defaultWindowsLevel;
        private readonly int _maxTrackBarValue;
        private readonly int _minTrackBarValue;
        private readonly Func<int, string> _resolveLabelLevel;
        private readonly List<ResolutionModeWrapper> _supportedResolutionList;
        private readonly IVibranceProxy _v;

        private bool _allowVisible;
        private List<ApplicationSetting> _applicationSettings;
        private IRegistryController _registryController;

        public VibranceGUI(
            Func<List<ApplicationSetting>, Dictionary<string, Tuple<ResolutionModeWrapper, List<ResolutionModeWrapper>>>
                , IVibranceProxy> getProxy,
            int defaultWindowsLevel,
            int minTrackBarValue,
            int maxTrackBarValue,
            int defaultIngameValue,
            Func<int, string> resolveLabelLevel)
        {
            _defaultWindowsLevel = defaultWindowsLevel;
            _minTrackBarValue = minTrackBarValue;
            _maxTrackBarValue = maxTrackBarValue;
            _defaultIngameValue = defaultIngameValue;
            _resolveLabelLevel = resolveLabelLevel;
            _allowVisible = true;

            InitializeComponent();

            trackBarWindowsLevel.Minimum = minTrackBarValue;
            trackBarWindowsLevel.Maximum = maxTrackBarValue;

            var windowsResolutionSettings = new Dictionary<string, Tuple<ResolutionModeWrapper, List<ResolutionModeWrapper>>>();
            foreach (var screen in Screen.AllScreens)
                if (ResolutionHelper.GetCurrentResolutionSettings(out var currentResolutionMode, screen.DeviceName))
                {
                    var availableResolutions = ResolutionHelper.EnumerateSupportedResolutionModes(screen.DeviceName);
                    if (screen.Primary) _supportedResolutionList = availableResolutions;
                    var tuple = new Tuple<ResolutionModeWrapper, List<ResolutionModeWrapper>>(
                        new ResolutionModeWrapper(currentResolutionMode), availableResolutions);
                    windowsResolutionSettings.Add(screen.DeviceName, tuple);
                }
                else
                {
                    MessageBox.Show("Current resolution mode could not be determined. Switching back to your Windows resolution will not work.");
                }

            _applicationSettings = new List<ApplicationSetting>();
            _v = getProxy(_applicationSettings, windowsResolutionSettings);

            backgroundWorker.WorkerReportsProgress = true;
            settingsBackgroundWorker.WorkerReportsProgress = true;

            backgroundWorker.RunWorkerAsync();
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!_allowVisible)
            {
                value = false;
                if (!IsHandleCreated) CreateHandle();
            }

            base.SetVisibleCore(value);
        }

        public void SetAllowVisible(bool value)
        {
            _allowVisible = value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetGuiEnabledFlag(false);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                // this.notifyIcon.Visible = true;
                // this.notifyIcon.BalloonTipText = "Running minimized... Like the program? Consider donating!";
                // this.notifyIcon.ShowBalloonTip(250);
                Hide();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var vibranceWindowsLevel = _defaultWindowsLevel;
            var affectPrimaryMonitorOnly = false;
            var neverSwitchResolution = false;

            while (!IsHandleCreated) Thread.Sleep(500);

            if (InvokeRequired)
                Invoke((MethodInvoker)delegate
                {
                    ReadVibranceSettings(out vibranceWindowsLevel, out affectPrimaryMonitorOnly,
                        out neverSwitchResolution);
                });
            else
                ReadVibranceSettings(out vibranceWindowsLevel, out affectPrimaryMonitorOnly, out neverSwitchResolution);

            if (!_v.GetVibranceInfo().isInitialized) return;
            backgroundWorker.ReportProgress(1);

            SetGuiEnabledFlag(true);

            _v.SetApplicationSettings(_applicationSettings);
            _v.SetShouldRun(true);
            _v.SetVibranceWindowsLevel(vibranceWindowsLevel);
            _v.SetAffectPrimaryMonitorOnly(affectPrimaryMonitorOnly);
            _v.SetNeverSwitchResolution(neverSwitchResolution);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (_v != null && _v.GetVibranceInfo().isInitialized) SetGuiEnabledFlag(true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanUp();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trackBarWindowsLevel_Scroll(object sender, EventArgs e)
        {
            _v.SetVibranceWindowsLevel(trackBarWindowsLevel.Value);
            labelWindowsLevel.Text = _resolveLabelLevel(trackBarWindowsLevel.Value);
            if (!settingsBackgroundWorker.IsBusy) settingsBackgroundWorker.RunWorkerAsync();
        }

        private void settingsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            ForceSaveVibranceSettings();
        }

        private void ForceSaveVibranceSettings()
        {
            var windowsLevel = 0;
            var affectPrimaryMonitorOnly = false;
            var neverSwitchResolution = false;
            Invoke((MethodInvoker)delegate
            {
                windowsLevel = trackBarWindowsLevel.Value;
                affectPrimaryMonitorOnly = checkBoxPrimaryMonitorOnly.Checked;
                neverSwitchResolution = checkBoxNeverChangeResolutions.Checked;
            });
            SaveVibranceSettings(windowsLevel, affectPrimaryMonitorOnly, neverSwitchResolution);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    statusLabel.Text = "Running!";
                    statusLabel.ForeColor = Color.Green;
                    break;
                case 2:
                    statusLabel.Text = $"NVAPI Unloaded: {e.UserState}";
                    break;
            }
        }

        private void settingsBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            _allowVisible = true;
            Show();

            WindowState = FormWindowState.Normal;
            Visible = true;

            Refresh();
            ShowInTaskbar = true;
        }

        private void checkBoxPrimaryMonitorOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (_v == null) return;

            _v.SetAffectPrimaryMonitorOnly(checkBoxPrimaryMonitorOnly.Checked);
            if (!settingsBackgroundWorker.IsBusy) settingsBackgroundWorker.RunWorkerAsync();
        }

        private void checkBoxNeverChangeResolutions_CheckedChanged(object sender, EventArgs e)
        {
            if (_v == null) return;

            _v.SetNeverSwitchResolution(checkBoxNeverChangeResolutions.Checked);
            if (!settingsBackgroundWorker.IsBusy) settingsBackgroundWorker.RunWorkerAsync();
        }

        private void checkBoxAutostart_CheckedChanged(object sender, EventArgs e)
        {
            var autostartController = new RegistryController();
            if (checkBoxAutostart.Checked)
            {
                var pathToExe = "\"" + Application.ExecutablePath + "\" -minimized";
                if (!autostartController.IsProgramRegistered(AppName))
                    notifyIcon.BalloonTipText = autostartController.RegisterProgram(AppName, pathToExe)
                        ? "Registered to Autostart!"
                        : "Registering to Autostart failed!";
                else if (!autostartController.IsStartupPathUnchanged(AppName, pathToExe))
                    notifyIcon.BalloonTipText = autostartController.RegisterProgram(AppName, pathToExe)
                        ? "Updated Autostart Path!"
                        : "Updating Autostart Path failed!";
                else
                    return;
            }
            else
            {
                notifyIcon.BalloonTipText = autostartController.UnregisterProgram(AppName)
                    ? "Unregistered from Autostart!"
                    : "Unregistering from Autostart failed!";
            }

            notifyIcon.ShowBalloonTip(250);
        }

        private void twitterToolStripTextBox_Click(object sender, EventArgs e)
        {
            Process.Start(TwitterLink);
        }

        private void linkLabelTwitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(TwitterLink);
        }

        private void linkLabelSefinek_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(SefinekWebsite);
        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(GitHubRepo);
        }

        private void SetGuiEnabledFlag(bool flag)
        {
            Invoke((MethodInvoker)delegate
            {
                trackBarWindowsLevel.Enabled = flag;
                checkBoxAutostart.Enabled = flag;
                checkBoxPrimaryMonitorOnly.Enabled = flag;
                buttonAddProgram.Enabled = flag;
                buttonProcessExplorer.Enabled = flag;
                buttonRemoveProgram.Enabled = flag;
            });
        }

        private void CleanUp()
        {
            try
            {
                statusLabel.Text = "Closing...";
                statusLabel.ForeColor = Color.Red;
                Update();

                if (_v == null || !_v.GetVibranceInfo().isInitialized) return;
                _v.HandleDvcExit();
                _v.SetShouldRun(false);
                _v.UnloadLibraryEx();
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        public static void Log(Exception ex)
        {
            using (var w = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "vibranceGUI.log")))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine("Exception Found:\nType: {0}", ex.GetType().FullName);
                w.WriteLine("Message: {0}", ex.Message);
                w.WriteLine("Source: {0}", ex.Source);
                w.WriteLine("Stacktrace: {0}", ex.StackTrace);
                w.WriteLine("Exception String: {0}", ex);

                w.WriteLine("-------------------------------");
            }
        }

        public static void Log(string msg)
        {
            using (var w = File.AppendText("vibranceGUI_log.txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine(msg);
                w.WriteLine("-------------------------------");
            }
        }

        private void ReadVibranceSettings(out int vibranceWindowsLevel, out bool affectPrimaryMonitorOnly,
            out bool neverSwitchResolution)
        {
            _registryController = new RegistryController();
            checkBoxAutostart.Checked = _registryController.IsProgramRegistered(AppName);

            var settingsController = new SettingsController();
            settingsController.ReadVibranceSettings(_v.GraphicsAdapter, out vibranceWindowsLevel,
                out affectPrimaryMonitorOnly, out neverSwitchResolution, out _applicationSettings);

            if (!IsHandleCreated) return;
            //no null check needed, SettingsController will always return matching values.
            labelWindowsLevel.Text = _resolveLabelLevel(vibranceWindowsLevel);

            trackBarWindowsLevel.Value = vibranceWindowsLevel;
            checkBoxPrimaryMonitorOnly.Checked = affectPrimaryMonitorOnly;
            checkBoxNeverChangeResolutions.Checked = neverSwitchResolution;
            foreach (var application in _applicationSettings.ToList())
            {
                if (!File.Exists(application.FileName))
                {
                    _applicationSettings.Remove(application);
                    continue;
                }

                InitializeApplicationList();

                var icon = Icon.ExtractAssociatedIcon(application.FileName);
                if (icon == null) continue;

                listApplications.LargeImageList.Images.Add(icon);
                var lvi = new ListViewItem(application.Name)
                {
                    ImageIndex = listApplications.Items.Count,
                    Tag = application.FileName
                };
                listApplications.Items.Add(lvi);
            }
        }

        private void SaveVibranceSettings(int windowsLevel, bool affectPrimaryMonitorOnly, bool neverSwitchResolution)
        {
            var settingsController = new SettingsController();

            settingsController.SetVibranceSettings(
                windowsLevel.ToString(),
                affectPrimaryMonitorOnly.ToString(),
                neverSwitchResolution.ToString(),
                _applicationSettings
            );
        }

        private void buttonPaypal_Click(object sender, EventArgs e)
        {
            Process.Start(PaypalDonationLink);
        }

        private void buttonAddProgram_Click(object sender, EventArgs e)
        {
            InitializeApplicationList();

            var fileDialog = new OpenFileDialog();
            var result = fileDialog.ShowDialog();
            if (result != DialogResult.OK || !fileDialog.CheckFileExists || fileDialog.SafeFileName == null ||
                _applicationSettings.FirstOrDefault(x => x.FileName.ToLower() == fileDialog.FileName.ToLower()) != null) return;
            var icon = Icon.ExtractAssociatedIcon(fileDialog.FileName);

            if (icon == null) return;
            var processExplorerEntry = new ProcessExplorerEntry(fileDialog.FileName, icon, Path.GetFileNameWithoutExtension(fileDialog.FileName));
            AddProgramIntern(processExplorerEntry);
        }

        public void AddProgramExtern(ProcessExplorerEntry processExplorerEntry)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { AddProgramIntern(processExplorerEntry); });
            else
                AddProgramIntern(processExplorerEntry);
        }

        private void AddProgramIntern(ProcessExplorerEntry processExplorerEntry)
        {
            InitializeApplicationList();

            if (!File.Exists(processExplorerEntry.Path) || _applicationSettings.FirstOrDefault(x => string.Equals(x.FileName, processExplorerEntry.Path, StringComparison.CurrentCultureIgnoreCase)) != null)
            {
                listApplications.SelectedIndices.Clear();
                return;
            }

            var icon = processExplorerEntry.Icon;
            var path = processExplorerEntry.Path;

            if (icon == null) return;
            listApplications.LargeImageList.Images.Add(icon);
            var lvi = new ListViewItem(Path.GetFileNameWithoutExtension(path))
            {
                ImageIndex = listApplications.Items.Count,
                Tag = path
            };
            listApplications.Items.Add(lvi);
            listApplications.SelectedIndices.Clear();
            lvi.Selected = true;
            listApplications_DoubleClick(this, EventArgs.Empty);
        }

        private void InitializeApplicationList()
        {
            if (listApplications.LargeImageList != null) return;
            var imageList = new ImageList
            {
                ImageSize = new Size(48, 48),
                ColorDepth = ColorDepth.Depth32Bit
            };
            listApplications.LargeImageList = imageList;
            ListViewItem_SetSpacing(listApplications, 48 + 24, 48 + 6 + 16);
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private static int MakeLong(short lowPart, short highPart)
        {
            return (int)((ushort)lowPart | (uint)(highPart << 16));
        }

        private static void ListViewItem_SetSpacing(IWin32Window listView, short leftPadding, short topPadding)
        {
            const int LVM_FIRST = 0x1000;
            const int LVM_SETICONSPACING = LVM_FIRST + 53;
            SendMessage(listView.Handle, LVM_SETICONSPACING, IntPtr.Zero, (IntPtr)MakeLong(leftPadding, topPadding));
        }

        private void listApplications_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = listApplications.SelectedItems[0];
            if (selectedItem == null) return;

            var actualSetting = _applicationSettings.FirstOrDefault(x => x.FileName == selectedItem.Tag.ToString());
            var settingsWindow = new VibranceSettings(_v, _minTrackBarValue, _maxTrackBarValue, _defaultIngameValue, selectedItem, actualSetting, _supportedResolutionList, _resolveLabelLevel);
            var result = settingsWindow.ShowDialog();
            if (result == DialogResult.OK)
            {
                var newSetting = settingsWindow.GetApplicationSetting();
                if (_applicationSettings.FirstOrDefault(x => x.FileName == newSetting.FileName) != null)
                    _applicationSettings.Remove(_applicationSettings.First(x => x.FileName == newSetting.FileName));
                _applicationSettings.Add(newSetting);
                ForceSaveVibranceSettings();
            }
            else if (actualSetting == null)
            {
                removeApplicationListItem(selectedItem);
            }
        }

        private void buttonRemoveProgram_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listApplications.SelectedItems)
            {
                for (var i = eachItem.Index + 1; i < listApplications.Items.Count; i++)
                    listApplications.Items[i].ImageIndex--;

                removeApplicationListItem(eachItem);
                _applicationSettings.Remove(
                    _applicationSettings.FirstOrDefault(x => x.FileName.Equals(eachItem.Tag.ToString())));
            }

            ForceSaveVibranceSettings();
        }

        private void removeApplicationListItem(ListViewItem item)
        {
            var img = listApplications.LargeImageList.Images[item.ImageIndex];
            listApplications.LargeImageList.Images.RemoveAt(item.ImageIndex);
            img.Dispose();
            listApplications.Items.Remove(item);
        }

        private void buttonProcessExplorer_Click(object sender, EventArgs e)
        {
            var ex = new ProcessExplorer(this);
            ex.Show();
        }
    }
}
