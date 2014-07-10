using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FireDeptFeesTool.Forms;
using FireDeptFeesTool.Helpers;
using FireDeptFeesTool.Lib;
using FireDeptFeesTool.Model;
using FireDeptFeesTool.ViewModels;

namespace FireDeptFeesTool.Controls
{
    public partial class MembersListControl : IListControl
    {
        private Dictionary<int, IList<int>> _changedCells;
        private bool _dataChanged;

        #region filter options

        private bool includeDeleted;
        private bool onlyMustPayers;

        #endregion filter options

        public MembersListControl(ShellForm container)
            : base(container)
        {
            _changedCells = new Dictionary<int, IList<int>>();
            DependantControls = new List<string>
                                    {
                                        "PaymentsListControl"
                                    };

            InitializeComponent();
            DrawHelper.EnableControlDoubleBuffering("DataGridView", membersDataGridView);
            BindMembersDataGridView();
        }

        public bool DataChanged
        {
            get { return _dataChanged; }
        }

        private void BindMembersDataGridView()
        {
            BindMembersDataGridView(onlyMustPayers, includeDeleted);

            // COLUMN HEADER TEXT
            /*
            membersDataGridView.Columns["VulkanID"].HeaderText = "Vulkan ID";
            membersDataGridView.Columns["Surname"].HeaderText = "Priimek";
            membersDataGridView.Columns["Name"].HeaderText = "Ime";
            membersDataGridView.Columns["Address"].HeaderText = "Naslov";
            membersDataGridView.Columns["DateOfBirth"].HeaderText = "Datum rojstva";
            membersDataGridView.Columns["Gender"].HeaderText = "Spol";
            membersDataGridView.Columns["MustPay"].HeaderText = "Obveznik";
            */

            // COLUMN EDITING
            /*
            membersDataGridView.Columns["VulkanID"].ReadOnly = true;
            membersDataGridView.Columns["DateOfBirth"].ReadOnly = true;
            membersDataGridView.Columns["Gender"].ReadOnly = true;
            membersDataGridView.Columns["MustPay"].ReadOnly = true;
            */
        }

        private void BindMembersDataGridView(bool onlyMustPayers, bool includeDeleted)
        {
            UpdateMustPayStatus();

            using (var db = new FeeStatusesDBContext())
            {
                membersBindingSource.DataSource = new SortableBindingList<MemberViewModel>
                    (
                    db.Member.
                        Where(m => !onlyMustPayers || m.MustPay).
                        Where(m => m.Active || includeDeleted).
                        OrderBy(m => m.Surname).
                        ThenBy(m => m.Name).
                        Select(m => new MemberViewModel
                                        {
                                            VulkanID = m.VulkanID,
                                            Surname = m.Surname,
                                            Name = m.Name,
                                            Address = m.Address,
                                            DateOfBirth = m.DateOfBirth,
                                            Gender = m.Gender ? "M" : "Ž",
                                            MustPay = m.MustPay ? "DA" : "NE",
                                            Active = m.Active
                                        }).ToList()
                    );
            }
            membersDataGridView.DataSource = membersBindingSource;

            membersDataGridView.Columns["Active"].Visible = false;

            ClearSelection(membersDataGridView);
        }

        private void UpdateMustPayStatus()
        {
            var menMustPay = ConfigHelper.GetConfigValue<bool>(ConfigFields.DOLZNI_CLANI);
            var womenMustPay = ConfigHelper.GetConfigValue<bool>(ConfigFields.DOLZNI_CLANI);

            var menFrom = ConfigHelper.GetConfigValue<int>(ConfigFields.OBDOBJE_CLANI_OD);
            var menTo = ConfigHelper.GetConfigValue<int>(ConfigFields.OBDOBJE_CLANI_DO);
            var womenFrom = ConfigHelper.GetConfigValue<int>(ConfigFields.OBDOBJE_CLANICE_OD);
            var womenTo = ConfigHelper.GetConfigValue<int>(ConfigFields.OBDOBJE_CLANICE_DO);

            using (var db = new FeeStatusesDBContext())
            {
                var members = db.Member.ToList();

                foreach (var member in members)
                {
                    member.MustPay = false;

                    var age = DateTime.Now.Year - member.DateOfBirth.Year;
                    if (member.Gender && menMustPay && age >= menFrom && age < menTo) // moški
                    {
                        member.MustPay = true;
                    }
                    else if (!member.Gender && womenMustPay && age >= womenFrom && age < womenTo) // ženske
                    {
                        member.MustPay = true;
                    }
                }

                db.SaveChanges();
            }
        }

        private bool SetMustPayStatus(bool gender, DateTime dateOfBirth)
        {
            var menMustPay = ConfigHelper.GetConfigValue<bool>(ConfigFields.DOLZNI_CLANI);
            var womenMustPay = ConfigHelper.GetConfigValue<bool>(ConfigFields.DOLZNI_CLANI);

            var menFrom = ConfigHelper.GetConfigValue<int>(ConfigFields.OBDOBJE_CLANI_OD);
            var menTo = ConfigHelper.GetConfigValue<int>(ConfigFields.OBDOBJE_CLANI_DO);
            var womenFrom = ConfigHelper.GetConfigValue<int>(ConfigFields.OBDOBJE_CLANICE_OD);
            var womenTo = ConfigHelper.GetConfigValue<int>(ConfigFields.OBDOBJE_CLANICE_DO);

            var age = DateTime.Now.Year - dateOfBirth.Year;
            if (gender && menMustPay && age >= menFrom && age < menTo) // moški
            {
                return true;
            }
            
            if (!gender && womenMustPay && age >= womenFrom && age < womenTo) // ženske
            {
                return true;
            }

            return false;
        }

        private void ImportMembersButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fullFilePath = openFileDialog.FileName;
                string onlyFileName = Path.GetFileName(fullFilePath);

                result =
                    MessageBox.Show("Ste prepričani da želite uvoziti podatke iz datoteke \"" + onlyFileName + "\"?",
                                    "Uvoz podatkov", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ImportMemberData(fullFilePath);
                    BindMembersDataGridView(onlyMustPayers, includeDeleted);
                }
            }
        }

        private void ImportMemberData(string fullFilePath)
        {
            bool dataExists;
            var idList = new List<string>();

            using (var db = new FeeStatusesDBContext())
            {
                if (
                    (dataExists = db.Member.Any()) &&
                    MessageBox.Show(
                        string.Format(WindowMessages.STORED_DATA_EXISTS_MSG, "članih"),
                        WindowMessages.STORED_DATA_EXISTS_TITLE,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        ) == DialogResult.No
                    )
                {
                    return;
                }
            }

            string line;
            using (var db = new FeeStatusesDBContext())
            {
                var memberData = new StreamReader(fullFilePath, Encoding.UTF8);

                if (db.Member.Any())
                    new ImportMembersDiffForm(memberData).ShowDialog();

                memberData = new StreamReader(fullFilePath, Encoding.UTF8);

                while ((line = memberData.ReadLine()) != null)
                {
                    string[] lineData = line.Split(';');

                    try
                    {
                        string vulkanId = lineData[0];
                        string name = lineData[2];
                        string surname = lineData[1];
                        DateTime dateOfBirth = DateTime.ParseExact(lineData[4], "d.M.yyyy", CultureInfo.InvariantCulture);
                        string address = lineData[6] + ", " + lineData[8] + " " + lineData[9];
                        bool gender = lineData[3].Equals("Moški"); // true == moski, false == zenska
                        bool mustPay = SetMustPayStatus(gender, dateOfBirth);

                        // TODO updating
                        Member existing;
                        if ((existing = db.Member.Find(vulkanId)) != null) // if exists member with VulkanID
                        {
                            existing.Name = name;
                            existing.Surname = surname;
                            existing.DateOfBirth = dateOfBirth;
                            existing.Address = address;
                            existing.Gender = gender;
                            existing.MustPay = mustPay;
                            //existing.Active = true;
                        }
                        else
                        {
                            db.Member.Add(
                                new Member
                                    {
                                        VulkanID = vulkanId,
                                        Name = name,
                                        Surname = surname,
                                        DateOfBirth = dateOfBirth,
                                        Address = address,
                                        Gender = gender,
                                        MustPay = mustPay,
                                        Active = true
                                    }
                                );
                        }

                        idList.Add(vulkanId);
                    }
                    catch (FormatException ex)
                    {
                        Debug.WriteLine(
                            "Datum rojstva ni v pravilni obliki. Trenutna vrstica je verjetno glava podatkov.");
                        Debug.WriteLine(ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.StackTrace);
                    }
                }

                if (dataExists)
                {
                    // mark those members that were not in the import file as inactive
                    db.Member.Where(m => !idList.Contains(m.VulkanID)).ToList().ForEach(m => m.Active = false);
                }

                db.SaveChanges();
            }
        }

        private void MembersDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_dataChanged)
            {
                if (e.ColumnIndex > 0)
                    _dataChanged = true;
            }
        }

        private void MembersDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // values dont change on load - they are just being loaded ...
            _dataChanged = false;
        }

        private void MembersDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (var b = new SolidBrush(membersDataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                                      e.RowBounds.Location.X + 25, e.RowBounds.Location.Y + 4);

                if (e.RowIndex > -1 && !(membersDataGridView.Rows[e.RowIndex].DataBoundItem as MemberViewModel).Active)
                {
                    membersDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }

        private void MembersDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
                return;

            DataGridViewColumn col = membersDataGridView.Columns[e.ColumnIndex];
            string sortDir;

            switch (col.HeaderCell.SortGlyphDirection)
            {
                case SortOrder.Ascending:
                    //membersDataGridView.Sort(col, ListSortDirection.Descending);
                    col.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                    sortDir = "DESC";
                    break;
                case SortOrder.Descending:
                    //membersDataGridView.Sort(col, ListSortDirection.Ascending);
                    col.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    sortDir = "ASC";
                    break;
                default:
                    //membersDataGridView.Sort(col, ListSortDirection.Ascending);
                    col.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    sortDir = "ASC";
                    break;
            }

            if (!string.IsNullOrEmpty(sortDir))
            {
                membersBindingSource.Sort = string.Join(" ", col.DataPropertyName, sortDir);
            }
            else
            {
                membersBindingSource.RemoveSort();
            }
        }

        private void AdditionalDisplayOptionsButton_Click(object sender, EventArgs e)
        {
            additionalDisplayOptionsContextMenuStrip.Show(additionalDisplayOptionsButton,
                                                          new Point(0, additionalDisplayOptionsButton.Height));
        }

        private void OnlyMustPayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onlyMustPayers = onlyMustPayersToolStripMenuItem.Checked;
            BindMembersDataGridView(onlyMustPayers, includeDeleted);
        }

        private void IncludeDeletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            includeDeleted = includeDeletedToolStripMenuItem.Checked;
            BindMembersDataGridView(onlyMustPayers, includeDeleted);
        }

        private void AdditionalActionsButton_Click(object sender, EventArgs e)
        {
            additionalActionsContextMenuStrip.Show(additionalActionsButton, new Point(0, additionalActionsButton.Height));
        }

        private void DeleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<DataGridViewRow> rows = membersDataGridView.Rows.Cast<DataGridViewRow>();

            using (var db = new FeeStatusesDBContext())
            {
                rows.ToList().ForEach(r =>
                                          {
                                              var row = r.DataBoundItem as MemberViewModel;

                                              if (row != null && row.Selected)
                                                  db.Member.Find(row.VulkanID).Active = false;
                                          }
                    );
                db.SaveChanges();
            }

            BindMembersDataGridView(onlyMustPayers, includeDeleted);
        }

        private void RestoreSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<DataGridViewRow> rows = membersDataGridView.Rows.Cast<DataGridViewRow>();

            using (var db = new FeeStatusesDBContext())
            {
                rows.ToList().ForEach(r =>
                                          {
                                              var row = r.DataBoundItem as MemberViewModel;
                                              if (row != null && row.Selected)
                                                  db.Member.Find(row.VulkanID).Active = true;
                                          }
                    );
                db.SaveChanges();
            }

            BindMembersDataGridView(onlyMustPayers, includeDeleted);
        }

        public override void SaveChanges(bool notifyUser)
        {
            membersBindingSource.EndEdit();

            if (_dataChanged)
            {
                using (var db = new FeeStatusesDBContext())
                {
                    if (notifyUser && DialogResult.No == MessageBox.Show(WindowMessages.SAVE_OR_DISCARD_CHANGES_MSG,
                                                                         WindowMessages.SAVE_OR_DISCARD_CHANGES_TITLE,
                                                                         MessageBoxButtons.YesNo,
                                                                         MessageBoxIcon.Warning))
                    {
                        ClearChanges();
                        return;
                    }

                    foreach (DataGridViewRow row in membersDataGridView.Rows)
                    {
                        var updatedMemberRow = row.DataBoundItem as MemberViewModel;
                        Member updatedMemberDBRow = updatedMemberRow.ToDBMember();

                        Member originalMemberDBRow = db.Member.Find(updatedMemberDBRow.VulkanID);

                        if (originalMemberDBRow != default(Member))
                        {
                            db.Entry(originalMemberDBRow).CurrentValues.SetValues(updatedMemberDBRow);
                        }
                    }

                    db.SaveChanges();
                }
                ClearChanges();
                NotifyDependantControlsOfChanges();
            }
        }

        public void ClearChanges()
        {
            _dataChanged = false;
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            SaveChanges(false);
        }

        public override void OnClosing()
        {
            SaveChanges(true);
        }

        private void MembersListControl_VisibleChanged(object sender, EventArgs e)
        {
            ClearSelection(membersDataGridView);
        }
    }
}