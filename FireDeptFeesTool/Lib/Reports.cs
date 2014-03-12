using System;
using System.Collections.Generic;
using System.Reflection;
using FireDeptFeesTool.Enums;
using FireDeptFeesTool.Helpers;
using Microsoft.Reporting.WinForms;

namespace FireDeptFeesTool.Lib
{
    public sealed class Reports
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ReportTypes Type { get; private set; }
        public string ReportPath { get; private set; }
        public List<ReportParameterControl> ParameterControls { get; private set; }

        #region reports instances

        public static readonly Reports ReportType1 = new Reports 
        {
            Type = ReportTypes.SELECTED_YEAR_NONPAYERS,
            Name = "Neplačniki za leto",
            Description = "Neplačniki za izbrano leto.",
            ReportPath = "FireDeptFeesTool.Reports.SelectedYearNonPayers.rdlc",
            ParameterControls = new List<ReportParameterControl>
                                    {
                                        new ReportParameterControl
                                            {
                                                Name = "SelectedYear",
                                                Label = "Leto",
                                                Control = ControlsHelper.CreateCustomFormatDateTimePicker("yyyy", DateTime.Now.AddYears(-1)),
                                                ParameterType = typeof(DateTime)
                                            },
                                    },
        };

        public static readonly Reports ReportType2 = new Reports
        {
            Type = ReportTypes.REGULAR_NONPAYERS,
            Name = "Redni neplačniki",
            Description = "Redni neplačniki.",
            ReportPath = "FireDeptFeesTool.Reports.RegularNonPayers.rdlc",
            ParameterControls = new List<ReportParameterControl>
                                    {
                                        new ReportParameterControl
                                            {
                                                Name = "FromYear",
                                                Label = "Od leta",
                                                Control = ControlsHelper.CreateCustomFormatDateTimePicker("yyyy", new DateTime(2008, 1, 1)),
                                                ParameterType = typeof(DateTime)
                                            },
                                    },
        };

        public static readonly Reports ReportType3 = new Reports
        {
            Type = ReportTypes.SELECTED_YEAR_STATISTICS,
            Name = "Statistika za leto",
            Description = "Statistika za izbrano leto.",
            ReportPath = "FireDeptFeesTool.Reports.StatisticsForYear.rdlc",
            ParameterControls = new List<ReportParameterControl>
                                    {
                                        new ReportParameterControl
                                            {
                                                Name = "SelectedYear",
                                                Label = "Leto",
                                                Control = ControlsHelper.CreateCustomFormatDateTimePicker("yyyy", DateTime.Now.AddYears(-1)),
                                                ParameterType = typeof(DateTime)
                                            },
                                    },
        };

        #endregion

        public static List<Reports> GetAll()
        {
            var retList = new List<Reports>();

            var fields = typeof (Reports).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var field in fields)
            {
                if (field.FieldType == typeof(Reports))
                {
                    retList.Add((Reports) field.GetValue(null));
                }
            }

            return retList;
        }

        public ReportDataSource GetDataSource(Dictionary<string, object> parameters)
        {
            return ReportDataSourceHelper.GetDataSource(Type, parameters);
        }
    }
}