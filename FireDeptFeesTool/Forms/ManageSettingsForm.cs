using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FireDeptFeesTool.Forms
{
    public partial class ManageSettingsForm : Form
    {
        public const string YEAR_DATETIME_FORMAT = "yyyy";
        public const string ONE_WHITESPACE_STRING = " ";

        public ManageSettingsForm()
        {
            InitializeComponent();

            nazivDrustvaTextBox.Text = ConfigurationManager.AppSettings["NazivDrustva"];
            IBANPrejemnikaTextBox.Text = ConfigurationManager.AppSettings["IBANPrejemnika"];
            BICBankeTextBox.Text = ConfigurationManager.AppSettings["BICBanke"];
            //znesekTextBox.Text = ConfigurationManager.AppSettings["Znesek"];

            dolzniClaniCheckBox.Checked = bool.Parse(ConfigurationManager.AppSettings["Dolzni_Clani"]);
            dolzniClaniceCheckBox.Checked = bool.Parse(ConfigurationManager.AppSettings["Dolzni_Clanice"]);
            obdobjeOdClaniNumericUpDown.Text = ConfigurationManager.AppSettings["Obdobje_Clani_Od"];
            obdobjeDoClaniNumericUpDown.Text = ConfigurationManager.AppSettings["Obdobje_Clani_Do"];
            znesekClaniTextBox.Text = ConfigurationManager.AppSettings["Znesek_Clani"];
            obdobjeOdClaniceNumericUpDown.Text = ConfigurationManager.AppSettings["Obdobje_Clanice_Od"];
            obdobjeDoClaniceNumericUpDown.Text = ConfigurationManager.AppSettings["Obdobje_Clanice_Do"];
            znesekClaniceTextBox.Text = ConfigurationManager.AppSettings["Znesek_Clanice"];

            DateTime dt;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Opomini_Od"]))
            {
                DateTime.TryParseExact(ConfigurationManager.AppSettings["Opomini_Od"], "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                obdobjeOdOpominiDateTimePicker.CustomFormat = YEAR_DATETIME_FORMAT;
                obdobjeOdOpominiDateTimePicker.Value = dt;
                obdobjeOdBrezOmejitveOpominiCheckBox.Checked = false;
            }
            else
            {
                obdobjeOdOpominiDateTimePicker.CustomFormat = ONE_WHITESPACE_STRING;
                obdobjeOdBrezOmejitveOpominiCheckBox.Checked = true;
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Opomini_Do"]))
            {
                DateTime.TryParseExact(ConfigurationManager.AppSettings["Opomini_Do"], "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                obdobjeDoOpominiDateTimePicker.CustomFormat = YEAR_DATETIME_FORMAT;
                obdobjeDoOpominiDateTimePicker.Value = dt;
                obdobjeDoBrezOmejitveOpominiCheckBox.Checked = false;
            }
            else
            {
                obdobjeDoOpominiDateTimePicker.CustomFormat = ONE_WHITESPACE_STRING;
                obdobjeDoBrezOmejitveOpominiCheckBox.Checked = true;
            }

            laserXOffsetTextBox.Text = ConfigurationManager.AppSettings["Laser_XOffset"];
            laserYOffsetTextBox.Text = ConfigurationManager.AppSettings["Laser_YOffset"];

            endlessXOffsetTextBox.Text = ConfigurationManager.AppSettings["Endless_XOffset"];
            endlessYOffsetTextBox.Text = ConfigurationManager.AppSettings["Endless_YOffset"];

            debtsTemplateTextBox.Text = ConfigurationManager.AppSettings["DebtsTemplate"];

            groupBox6.Enabled = dolzniClaniCheckBox.Checked;
            groupBox7.Enabled = dolzniClaniceCheckBox.Checked;
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["NazivDrustva"].Value = nazivDrustvaTextBox.Text;
            config.AppSettings.Settings["IBANPrejemnika"].Value = IBANPrejemnikaTextBox.Text;
            config.AppSettings.Settings["BICBanke"].Value = BICBankeTextBox.Text;
            //config.AppSettings.Settings["Znesek"].Value = znesekTextBox.Text;

            config.AppSettings.Settings["Dolzni_Clani"].Value = dolzniClaniCheckBox.Checked ? bool.TrueString : bool.FalseString;
            config.AppSettings.Settings["Dolzni_Clanice"].Value = dolzniClaniceCheckBox.Checked ? bool.TrueString : bool.FalseString;
            config.AppSettings.Settings["Obdobje_Clani_Od"].Value = obdobjeOdClaniNumericUpDown.Text;
            config.AppSettings.Settings["Obdobje_Clani_Do"].Value = obdobjeDoClaniNumericUpDown.Text;
            config.AppSettings.Settings["Znesek_Clani"].Value = znesekClaniTextBox.Text;
            config.AppSettings.Settings["Obdobje_Clanice_Od"].Value = obdobjeOdClaniceNumericUpDown.Text;
            config.AppSettings.Settings["Obdobje_Clanice_Do"].Value = obdobjeDoClaniceNumericUpDown.Text;
            config.AppSettings.Settings["Znesek_Clanice"].Value = znesekClaniceTextBox.Text;

            config.AppSettings.Settings["Opomini_Od"].Value = obdobjeOdOpominiDateTimePicker.CustomFormat == YEAR_DATETIME_FORMAT
                ? obdobjeOdOpominiDateTimePicker.Value.Year.ToString(CultureInfo.InvariantCulture)
                : string.Empty;
            config.AppSettings.Settings["Opomini_Do"].Value = obdobjeDoOpominiDateTimePicker.CustomFormat == YEAR_DATETIME_FORMAT
                ? obdobjeDoOpominiDateTimePicker.Value.Year.ToString(CultureInfo.InvariantCulture)
                : string.Empty;

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

        private void Button2_Click(object sender, EventArgs e)
        {
            selectTemplateOpenFileDialog.InitialDirectory =
                Path.GetDirectoryName(Path.GetFullPath(debtsTemplateTextBox.Text));
            //selectTemplateOpenFileDialog.FileName = System.IO.Path.GetFileName(System.IO.Path.GetFullPath(debtsTemplateTextBox.Text));

            if (selectTemplateOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                debtsTemplateTextBox.Text = selectTemplateOpenFileDialog.FileName;
            }
        }

        private void ScrollPanel_MouseEnter(object sender, EventArgs e)
        {
            scrollPanel.Focus();
        }

        private void DolzniClaniceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            groupBox7.Enabled = dolzniClaniceCheckBox.Checked;
        }

        private void DolzniClaniCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            groupBox6.Enabled = dolzniClaniCheckBox.Checked;
        }

        private void ObdobjeOdBrezOmejitveOpominiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                obdobjeOdOpominiDateTimePicker.CustomFormat = ONE_WHITESPACE_STRING;
                obdobjeOdOpominiDateTimePicker.Enabled = false;
            }
            else
            {
                obdobjeOdOpominiDateTimePicker.CustomFormat = YEAR_DATETIME_FORMAT;
                obdobjeOdOpominiDateTimePicker.Enabled = true;
            }
        }

        private void ObdobjeDoBrezOmejitveOpominiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                obdobjeDoOpominiDateTimePicker.CustomFormat = ONE_WHITESPACE_STRING;
                obdobjeDoOpominiDateTimePicker.Enabled = false;
            }
            else
            {
                obdobjeDoOpominiDateTimePicker.CustomFormat = YEAR_DATETIME_FORMAT;
                obdobjeDoOpominiDateTimePicker.Enabled = true;
            }
        }
    }
}