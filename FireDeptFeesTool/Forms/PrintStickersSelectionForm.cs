using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireDeptFeesTool.Controls;

namespace FireDeptFeesTool.Forms
{
    public partial class PrintStickersSelectionForm : Form
    {
        private BillsListControl parent;

        private static readonly Dictionary<string, string> availableFormats = new Dictionary<string, string>
                                                                           {
                                                                               { "FireDeptFeesTool.Reports.MemberStickers2x6.rdlc", "A4 - 2x6"},
                                                                               { "FireDeptFeesTool.Reports.MemberStickers3x8.rdlc", "A4 - 3x8"}
                                                                           };

        public PrintStickersSelectionForm(BillsListControl parent)
        {
            InitializeComponent();
            this.parent = parent;

            BindStickersFormatComboBoxValues();
        }

        private void BindStickersFormatComboBoxValues()
        {
            stickerFormatsComboBox.DataSource = new BindingSource(availableFormats, null);
            stickerFormatsComboBox.ValueMember = "Key";
            stickerFormatsComboBox.DisplayMember = "Value";
        }

        private void StickersFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var format = (KeyValuePair<string, string>) stickerFormatsComboBox.SelectedItem;

            if (format.Key == null)
                return;

            parent.stickerFormat = format.Key;

            var matches = Regex.Matches(format.Key, @"[0-9]+");

            if (matches.Count < 2)
                return;

            BuildButtonList(Int32.Parse(matches[1].Value), Int32.Parse(matches[0].Value));
        }

        private void BuildButtonList(int rows, int cols)
        {
            var rowPercentage = 100/rows;
            var colPercantage = 100/cols;

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            for (var i = 0; i < rows; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, rowPercentage));
            }
            tableLayoutPanel1.RowCount = rows;

            for (var j = 0; j < cols; j++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, colPercantage));
            }
            tableLayoutPanel1.ColumnCount = cols;

            var offset = 1;
            for (var j = 0; j < cols; j++)
            {
                for (var i = 0; i < rows; i++)
                {
                    var button = new Button
                                     {
                                         Text = (i + offset).ToString(),
                                         Dock = DockStyle.Fill,
                                         DialogResult = DialogResult.OK
                                     };
                    button.Click += PrintStickerButton_Click;

                    tableLayoutPanel1.Controls.Add(button, j, i);
                }

                offset += rows;
            }

            tableLayoutPanel1.Refresh();
        }

        private void PrintStickerButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button == null)
                return;

            parent.stickersToSkip = Int32.Parse(button.Text) - 1;

            DialogResult = button.DialogResult;
            
            HideAndClose();
        }

        private void HideAndClose()
        {
            this.Hide();
            this.Dispose();
            this.Close();
        }
    }
}
