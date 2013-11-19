using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace FireDeptFeesTool.Forms
{
    public partial class ManageSettingsForm : Form
    {
        public ManageSettingsForm()
        {
            InitializeComponent();

            nazivDrustvaTextBox.Text = ConfigurationManager.AppSettings["NazivDrustva"];
            IBANPrejemnikaTextBox.Text = ConfigurationManager.AppSettings["IBANPrejemnika"];
            BICBankeTextBox.Text = ConfigurationManager.AppSettings["BICBanke"];
            znesekTextBox.Text = ConfigurationManager.AppSettings["Znesek"];

            laserXOffsetTextBox.Text = ConfigurationManager.AppSettings["Laser_XOffset"];
            laserYOffsetTextBox.Text = ConfigurationManager.AppSettings["Laser_YOffset"];

            endlessXOffsetTextBox.Text = ConfigurationManager.AppSettings["Endless_XOffset"];
            endlessYOffsetTextBox.Text = ConfigurationManager.AppSettings["Endless_YOffset"];

            debtsTemplateTextBox.Text = ConfigurationManager.AppSettings["DebtsTemplate"];
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["NazivDrustva"].Value = nazivDrustvaTextBox.Text;
            config.AppSettings.Settings["IBANPrejemnika"].Value = IBANPrejemnikaTextBox.Text;
            config.AppSettings.Settings["BICBanke"].Value = BICBankeTextBox.Text;
            config.AppSettings.Settings["Znesek"].Value = znesekTextBox.Text;

            config.AppSettings.Settings["Laser_XOffset"].Value = laserXOffsetTextBox.Text;
            config.AppSettings.Settings["Laser_YOffset"].Value = laserYOffsetTextBox.Text;

            config.AppSettings.Settings["Endless_XOffset"].Value = endlessXOffsetTextBox.Text;
            config.AppSettings.Settings["Endless_YOffset"].Value = endlessYOffsetTextBox.Text;

            config.AppSettings.Settings["DebtsTemplate"].Value = debtsTemplateTextBox.Text;

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

            Hide();
            Dispose();
        }

        private void CancelSettingsButton_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectTemplateOpenFileDialog.InitialDirectory =
                Path.GetDirectoryName(Path.GetFullPath(debtsTemplateTextBox.Text));
            //selectTemplateOpenFileDialog.FileName = System.IO.Path.GetFileName(System.IO.Path.GetFullPath(debtsTemplateTextBox.Text));

            if (selectTemplateOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                debtsTemplateTextBox.Text = selectTemplateOpenFileDialog.FileName;
            }
        }
    }
}