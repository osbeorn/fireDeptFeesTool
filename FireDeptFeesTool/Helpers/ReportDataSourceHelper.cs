﻿using System;
using System.Collections.Generic;
using System.Linq;
using FireDeptFeesTool.Enums;
using FireDeptFeesTool.Model;
using FireDeptFeesTool.ReportModels;
using Microsoft.Reporting.WinForms;

namespace FireDeptFeesTool.Helpers
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
                               l.PaymentStatusID == PaymentStatus.NI_PLACAL
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
                
                return
                    db.FeeLogs
                        .Where(l =>
                               l.Year >= year &&
                               l.PaymentStatusID == PaymentStatus.NI_PLACAL &&
                               l.Member.MustPay
                        )
                        .GroupBy(l => l.Member)
                        .Select(group =>
                                new RegularNonPayersReportModel
                                    {
                                        VulkanID = group.Key.VulkanID,
                                        Name = group.Key.Name,
                                        Surname = group.Key.Surname,
                                        Count = group.Count()
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
                                        PaymentStatusID = l.PaymentStatusID
                                    }
                        )
                        .ToList();

                foreach (var obj in list)
                {
                    obj.PaymentStatusDesc = PaymentStatus.GetPaymentStatusText(obj.PaymentStatusID);
                }

                return list;
            }
        }
    }
}