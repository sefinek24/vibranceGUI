using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace vibrance.GUI.common
{
    public partial class ProcessExplorer : Form
    {
        private readonly Form vibranceGui;

        public ProcessExplorer(Form vibranceGui)
        {
            InitializeComponent();

            listView.Columns.Add("Programs", 130, HorizontalAlignment.Left);
            listView.Columns.Add("Full Path", 320, HorizontalAlignment.Left);
            listView.LargeImageList = iconList;
            listView.FullRowSelect = true;
            listView.View = View.Tile;
            listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            this.vibranceGui = vibranceGui;

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void GetAllProcesses()
        {
            var activeProcceses = Process.GetProcesses();
            var activeApplicationCount = 0;
            foreach (var process in activeProcceses)
                if (process.MainWindowHandle != IntPtr.Zero && process.Id != Process.GetCurrentProcess().Id)
                    try
                    {
                        var path = GetPathFromProcessId(process);
                        if (path != string.Empty && File.Exists(path))
                        {
                            var processEntry = new ProcessExplorerEntry(path, Icon.ExtractAssociatedIcon(path), process);
                            backgroundWorker.ReportProgress(++activeApplicationCount, processEntry);
                        }
                    }
                    catch (Exception ex)
                    {
                        VibranceGUI.Log(ex);
                    }
        }

        [DllImport("psapi.dll")]
        private static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In] [MarshalAs(UnmanagedType.U4)] int nSize);

        /// <summary>
        ///     Safely gets the executable path from the specified process.
        ///     Process.MainModule.FileName crashes when called on a x64 process because vibranceGUI is running as x86 process.
        /// </summary>
        /// <param name="process">the process to read out the executable path of</param>
        /// <returns>the fully qualified executable path</returns>
        private string GetPathFromProcessId(Process process)
        {
            var sb = new StringBuilder(1024);
            if (GetModuleFileNameEx(process.Handle, IntPtr.Zero, sb, sb.Capacity) > 0) return sb.ToString();
            return string.Empty;
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                var processExplorerEntry = (ProcessExplorerEntry)listView.SelectedItems[0].Tag;
                if (processExplorerEntry == null) return;
                Hide();
                ((VibranceGUI)vibranceGui).AddProgramExtern(processExplorerEntry);
                Close();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                listView.Items.Clear();
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetAllProcesses();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!(e.UserState is ProcessExplorerEntry)) return;
            var processEntry = (ProcessExplorerEntry)e.UserState;
            iconList.Images.Add(processEntry.Icon);
            var listItem = new ListViewItem(processEntry.ProcessName, iconList.Images.Count - 1);
            listItem.Tag = processEntry;
            listItem.SubItems.Add(processEntry.Path);
            listView.Items.Add(listItem);
        }
    }
}
