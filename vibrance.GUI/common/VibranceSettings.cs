using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace vibrance.GUI.common
{
    public partial class VibranceSettings : Form
    {
        private readonly Func<int, string> _resolveLabelLevel;
        private readonly ListViewItem _sender;
        private readonly IVibranceProxy _v;

        public VibranceSettings(IVibranceProxy v, int minValue, int maxValue, int defaultValue, ListViewItem sender, ApplicationSetting setting, List<ResolutionModeWrapper> supportedResolutionList,
            Func<int, string> resolveLabelLevel)
        {
            InitializeComponent();
            trackBarIngameLevel.Minimum = minValue;
            trackBarIngameLevel.Maximum = maxValue;
            trackBarIngameLevel.Value = defaultValue;
            _sender = sender;
            _resolveLabelLevel = resolveLabelLevel;
            _v = v;
            labelIngameLevel.Text = _resolveLabelLevel(trackBarIngameLevel.Value);
            labelTitle.Text += $@"""{sender.Text}""";
            pictureBox.Image = _sender.ListView.LargeImageList.Images[_sender.ImageIndex];
            cBoxResolution.DataSource = supportedResolutionList;
            // If the setting is new, we don't need to set the progress bar value
            if (setting != null)
            {
                // Sets the progress bar value to the Ingame Vibrance setting
                trackBarIngameLevel.Value = setting.IngameLevel;
                cBoxResolution.SelectedItem = setting.ResolutionSettings;
                checkBoxResolution.Checked = setting.IsResolutionChangeNeeded;
                // Necessary to reload the label which tells the percentage
                trackBarIngameLevel_Scroll(null, null);
            }
        }

        private void trackBarIngameLevel_Scroll(object sender, EventArgs e)
        {
            _v.SetVibranceIngameLevel(trackBarIngameLevel.Value);
            labelIngameLevel.Text = _resolveLabelLevel(trackBarIngameLevel.Value);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public ApplicationSetting GetApplicationSetting()
        {
            return new ApplicationSetting(_sender.Text, _sender.Tag.ToString(), trackBarIngameLevel.Value,
                (ResolutionModeWrapper)cBoxResolution.SelectedItem, checkBoxResolution.Checked);
        }

        private void checkBoxResolution_CheckedChanged(object sender, EventArgs e)
        {
            cBoxResolution.Enabled = checkBoxResolution.Checked;
        }
    }
}
