﻿using System;
using System.Collections.Generic;
using System.Linq;
using FireDeptFeesTool.Common.Enums;
using FireDeptFeesTool.Model.Main;
using FireDeptFeesTool.Model.Report;
using Microsoft.Reporting.WinForms;

namespace FireDeptFeesTool.Common.Helpers
{
    public class ReportDataSourceHelper
    {
        public static ReportDataSource GetDataSource(ReportTypes report, Dictionary<string, object> parameters)
        {
            switch (report)
            {
                case ReportTypes.SELECTED_YEAR_NONPAYERS:
                    return new ReportDataSource("DataSet1", SelectedYearNonPayersDataSet(parameters));
                case ReportTypes.REGULAR_NONPAYERS:
                    return new ReportDataSource("DataSet1", RegularNonPayersDataSet(parameters));
                case ReportTypes.SELECTED_YEAR_STATISTICS:
                    return new ReportDataSource("DataSet1", SelectedYearStatisticsDataSet(parameters));
                default:
                    break;
            }

            return new ReportDataSource("DataSet1");
        }

        public static List<SelectedYearNonPayersReportModel> SelectedYearNonPayersDataSet(Dictionary<string, object> parameters)
        {
            using (var db = new FeeStatusesDBContext())
            {
                var dateTime = parameters["SelectedYear"] as DateTime?;
                var year = dateTime.HasValue ? dateTime.Value.Year : 0;

                return
                    db.FeeLogs
                        .Where(l => 
                               l.Year == year &&
                               l.PaymentStatus == PaymentStatusEnum.NI_PLACAL &&
                               l.Member.MustPay &&
                               l.Member.Active
                        )
                        .Select(x => 
                                new SelectedYearNonPayersReportModel
                                    {
                                        VulkanID = x.Member.VulkanID,
                                        Name = x.Member.Name,
                                        Surname = x.Member.Surname
                                    }
                        )
                        .ToList();
            }
        }

        public static List<RegularNonPayersReportModel> RegularNonPayersDataSet(Dictionary<string, object> parameters)
        {
            using (var db = new FeeStatusesDBContext())
            {
                var dateTime = parameters["FromYear"] as DateTime?;
                var year = dateTime.HasValue ? dateTime.Value.Year : 0;

                var logsList = db.FeeLogs
                                   .Where(l =>
                                          l.Year >= year &&
                                          l.PaymentStatus == PaymentStatusEnum.NI_PLACAL &&
                                          l.Member.MustPay &&
                                          l.Member.Active
                                    )
                                    .ToList();

                return logsList
                           .GroupBy(l => l.Member)
                           .Select(group =>
                                   new RegularNonPayersReportModel
                                   {
                                       VulkanID = group.Key.VulkanID,
                                       Name = group.Key.Name,
                                       Surname = group.Key.Surname,
                                       Count = group.Count(),
                                       Years = group.Select(l => l.Year.ToString()).Aggregate((y1, y2) => String.Join(", ", y1, y2))
                                   }
                           )
                           .ToList();
            }
        }

        public static List<SelectedYearStatisticsReportModel> SelectedYearStatisticsDataSet(Dictionary<string, object> parameters)
        {
            using (var db = new FeeStatusesDBContext())
            {
                var dateTime = parameters["SelectedYear"] as DateTime?;
                var year = dateTime.HasValue ? dateTime.Value.Year : 0;

                var list =
                    db.FeeLogs
                        .Where(l =>
                               l.Year == year && l.Member.MustPay
                        )
                        .Select(l =>
                                new SelectedYearStatisticsReportModel
                                    {
                                        PaymentStatus = (int) l.PaymentStatus
                                    }
                        )
                        .ToList();

                foreach (var obj in list)
                {
                    obj.PaymentStatusDesc = PaymentStatusHelper.GetPaymentStatusText(obj.PaymentStatus);
                }

                return list;
            }
        }
    }
}