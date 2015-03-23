using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FireDeptFeesTool.Helpers;
using FireDeptFeesTool.Lib;
using FireDeptFeesTool.Model;
using FireDeptFeesTool.ViewModels;

namespace FireDeptFeesTool.Forms
{
    public partial class ImportMembersDiffForm : Form
    {
        private List<Member> newMembers; 

        public ImportMembersDiffForm(StreamReader memberData)
        {
            InitializeComponent();
            DrawHelper.EnableControlDoubleBuffering("DataGridView", membersDiffDataGridView);
            BindMembersDiffDataGridView(memberData);
        }

        private void BindMembersDiffDataGridView(StreamReader memberData)
        {
            var membersDiff = new List<MemberDiffViewModel>();
            newMembers = new List<Member>();

            using (var db = new FeeStatusesDBContext())
            {
                string line;

                while ((line = memberData.ReadLine()) != null)
                {
                    var lineData = line.Split(';');

                    try
                    {
                        var vulkanId = lineData[0];
                        var name = lineData[2];
                        var surname = lineData[1];
                        var dateOfBirth = DateTime.ParseExact(lineData[4], "d.M.yyyy", CultureInfo.InvariantCulture);
                        var address = lineData[6] + ", " + lineData[8] + " " + lineData[9];
                        var gender = lineData[3].Equals("Moški"); // true == moski, false == zenska

                        newMembers.Add(
                            new Member
                                {
                                    VulkanID = vulkanId,
                                    Name = name,
                                    Surname = surname,
                                    DateOfBirth = dateOfBirth,
                                    Address = address,
                                    Gender = gender
                                }
                            );
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.StackTrace);
                    }
                }

                var members = db.Member;
                foreach (var member in members)
                {
                    membersDiff.Add(
                        new MemberDiffViewModel(
                            member,
                            newMembers.FirstOrDefault(m => m.VulkanID == member.VulkanID)
                        )
                    );
                }

                var temp = newMembers.Where(m => !members.Select(x => x.VulkanID).Contains(m.VulkanID));
                membersDiff.AddRange(
                    temp.Select(t => new MemberDiffViewModel(null, t))
                );
            }

            membersDiffDataGridView.DataSource = new SortableBindingList<MemberDiffViewModel>(membersDiff);
        }

        #region Event handlers

        private void MembersDiffDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 11)
            {
                var rect = e.CellBounds;

                using (var p = new Pen(Color.Black, 4))
                {
                    e.Paint(e.CellBounds, e.PaintParts);
                    e.Graphics.DrawLine(p, new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Bottom));
                    e.Handled = true;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion
    }
}