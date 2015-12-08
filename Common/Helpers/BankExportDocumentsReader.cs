using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using FireDeptFeesTool.Common.Lib;
using FireDeptFeesTool.Model.Main;
using FireDeptFeesTool.Schemas.Camt05300102;
using FireDeptFeesTool.Model.View;

namespace FireDeptFeesTool.Common.Helpers
{
    public class BankExportDocumentsReader
    {
        public static List<BankExportDocumentSelectionViewModel> ParseBankExportDocuments(string filePath)
        {
            List<BankExportDocumentSelectionViewModel> retList = null;

            try
            {
                retList = TryParseSepaXMLDocument(filePath);
            }
            catch (Exception)
            {
                try
                {
                    retList = TryParseTKDISDocument(filePath);
                }
                catch
                {
                    MessageBox.Show("Neveljaven format dokumenta za uvoz.");
                }
            }

            return retList;
        }

        public static List<BankExportDocumentSelectionViewModel> TryParseTKDISDocument(string filePath)
        {
            using (var db = new FeeStatusesDBContext())
            {
                var file = new StreamReader(filePath, Encoding.UTF8);
                var tempList = new List<BankExportDocument>();

                try
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        tempList.Add(new BankExportDocument(line));
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }

                IQueryable<string> vulkanIds = db.Member.Where(m => m.MustPay && m.Active).Select(m => m.VulkanID);
                IEnumerable<Member> members = db.Member.AsEnumerable();
                var retList = new List<BankExportDocumentSelectionViewModel>();

                tempList.
                    Where(l => l.OznakaKnjizenja == "20").
                    ToList().
                    ForEach(l =>
                                {
                                    int? year = null;
                                    string vulkanId = null;

                                    string[] split = l.SklicOdobritve.Split('-');
                                    // || nazivPartnerja == permutations(name, surname)

                                    if (
                                        (split.Length == 2 && vulkanIds.Contains(split[1])) ||
                                        (members.Any(m =>
                                                     l.NazivPartnerja.Equals
                                                         (
                                                             m.NameUpperWOSumniki +
                                                             " " +
                                                             m.SurnameUpperWOSumniki
                                                         )
                                                     ||
                                                     l.NazivPartnerja.Equals
                                                         (
                                                             m.SurnameUpperWOSumniki +
                                                             " " +
                                                             m.NameUpperWOSumniki
                                                         ))
                                        )
                                        )
                                    {
                                        if (l.SklicOdobritve.Contains('-'))
                                        {
                                            year = int.Parse(l.SklicOdobritve.Split('-')[0]);
                                            vulkanId = l.SklicOdobritve.Split('-')[1];
                                        }

                                        retList.Add(
                                            new BankExportDocumentSelectionViewModel
                                                {
                                                    Member = vulkanId,
                                                    Years =
                                                        year.HasValue
                                                            ? year.Value.ToString(CultureInfo.InvariantCulture)
                                                            : "",
                                                    BankDocData =
                                                        l.NazivPartnerja + "; " + l.Namen + "; " + l.Znesek + "€",
                                                    Warning =
                                                        l.Znesek > 10 ||
                                                        vulkanId == null ||
                                                        !year.HasValue,
                                                    Selected =
                                                        vulkanId != null
                                                        && year.HasValue
                                                        && l.Znesek == 10
                                                }
                                            );
                                    }
                                });

                return retList;
            }
        }

        public static List<BankExportDocumentSelectionViewModel> TryParseSepaXMLDocument(string filePath)
        {
            using (var db = new FeeStatusesDBContext())
            {
                XmlReader reader =
                    XmlReader.Create(
                        File.OpenRead(filePath));
                var serializer =
                    new XmlSerializer(
                        typeof (Document));
                var obj = (Document) serializer.Deserialize(reader);

                var retList = new List<BankExportDocumentSelectionViewModel>();
                IQueryable<string> vulkanIds = db.Member.Where(m => m.MustPay && m.Active).Select(m => m.VulkanID);
                IEnumerable<Member> members = db.Member.AsEnumerable();

                obj.BkToCstmrStmt.Stmt.
                    SelectMany(s => s.Ntry).
                    ToList().
                    Where(n => n.CdtDbtInd == CreditDebitCode.CRDT).
                    ToList().
                    ForEach(n =>
                                {
                                    int? year = null;
                                    string vulkanId = null;

                                    EntryTransaction2 txDtls = n.NtryDtls.First().TxDtls.First();
                                    string @ref = txDtls.RmtInf.Strd.First().CdtrRefInf.Ref;
                                    string refInfo = txDtls.RmtInf.Strd.First().AddtlRmtInf.First();
                                    PartyIdentification32 dbtr = txDtls.RltdPties.Dbtr; // info o placniku

                                    string[] split = @ref.Split('-');
                                    if (
                                        (split.Length == 2 && vulkanIds.Contains(split[1])) ||
                                        (members.Any(m =>
                                                     dbtr.Nm.Equals
                                                         (
                                                             m.NameUpperWOSumniki +
                                                             " " +
                                                             m.SurnameUpperWOSumniki
                                                         )
                                                     ||
                                                     dbtr.Nm.Equals
                                                         (
                                                             m.SurnameUpperWOSumniki +
                                                             " " +
                                                             m.NameUpperWOSumniki
                                                         ))
                                        )
                                        )
                                    {
                                        string subRef = @ref.Substring(4); // remove SIXX

                                        if (subRef.Contains('-'))
                                        {
                                            year = int.Parse(subRef.Split('-')[0]);
                                            vulkanId = subRef.Split('-')[1];
                                        }

                                        retList.Add(new BankExportDocumentSelectionViewModel
                                                        {
                                                            Member = vulkanId,
                                                            Years =
                                                                year.HasValue
                                                                    ? year.Value.ToString(CultureInfo.InvariantCulture)
                                                                    : "",
                                                            BankDocData =
                                                                dbtr.Nm + "; " + refInfo + "; " + n.Amt.Value + "€",
                                                            Warning =
                                                                n.Amt.Value > 10 ||
                                                                vulkanId == null ||
                                                                !year.HasValue,
                                                            Selected =
                                                                vulkanId != null &&
                                                                year.HasValue &&
                                                                n.Amt.Value == 10
                                                        });
                                    }
                                }
                    );
                return retList;
            }
        }
    }
}