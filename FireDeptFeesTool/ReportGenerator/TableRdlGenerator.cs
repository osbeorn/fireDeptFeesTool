using System.Collections.Generic;
using FireDeptFeesTool.Lib;
using Rdl;

namespace DynamicTable
{
    internal class TableRdlGenerator
    {
        private List<ReportColumn> m_fields;

        public List<ReportColumn> Fields
        {
            get { return m_fields; }
            set { m_fields = value; }
        }

        public TableType CreateTable()
        {
            var table = new TableType();
            table.Name = "Table1";
            table.Items = new object[]
                              {
                                  CreateTableColumns(),
                                  CreateHeader(),
                                  CreateDetails(),
                              };
            table.ItemsElementName = new[]
                                         {
                                             ItemsChoiceType21.TableColumns,
                                             ItemsChoiceType21.Header,
                                             ItemsChoiceType21.Details,
                                         };
            return table;
        }

        private HeaderType CreateHeader()
        {
            var header = new HeaderType();
            header.Items = new object[]
                               {
                                   CreateHeaderTableRows(),
                                   true,
                               };
            header.ItemsElementName = new[]
                                          {
                                              ItemsChoiceType20.TableRows,
                                              ItemsChoiceType20.RepeatOnNewPage
                                          };
            return header;
        }

        private TableRowsType CreateHeaderTableRows()
        {
            var headerTableRows = new TableRowsType();
            headerTableRows.TableRow = new[] {CreateHeaderTableRow()};
            return headerTableRows;
        }

        private TableRowType CreateHeaderTableRow()
        {
            var headerTableRow = new TableRowType();
            headerTableRow.Items = new object[] {CreateHeaderTableCells(), "0.25in"};
            return headerTableRow;
        }

        private TableCellsType CreateHeaderTableCells()
        {
            var headerTableCells = new TableCellsType();
            headerTableCells.TableCell = new TableCellType[m_fields.Count];
            for (int i = 0; i < m_fields.Count; i++)
            {
                headerTableCells.TableCell[i] = CreateHeaderTableCell(m_fields[i]);
            }
            return headerTableCells;
        }

        private TableCellType CreateHeaderTableCell(ReportColumn field)
        {
            var headerTableCell = new TableCellType();
            headerTableCell.Items = new object[] {CreateHeaderTableCellReportItems(field)};
            return headerTableCell;
        }

        private ReportItemsType CreateHeaderTableCellReportItems(ReportColumn field)
        {
            var headerTableCellReportItems = new ReportItemsType();
            headerTableCellReportItems.Items = new object[] {CreateHeaderTableCellTextbox(field)};
            return headerTableCellReportItems;
        }

        private TextboxType CreateHeaderTableCellTextbox(ReportColumn field)
        {
            var headerTableCellTextbox = new TextboxType();
            headerTableCellTextbox.Name = field.Name + "_Header";
            headerTableCellTextbox.Items = new object[]
                                               {
                                                   field.Value,
                                                   CreateHeaderTableCellTextboxStyle(),
                                                   true,
                                               };
            headerTableCellTextbox.ItemsElementName = new[]
                                                          {
                                                              ItemsChoiceType14.Value,
                                                              ItemsChoiceType14.Style,
                                                              ItemsChoiceType14.CanGrow,
                                                          };
            return headerTableCellTextbox;
        }

        private StyleType CreateHeaderTableCellTextboxStyle()
        {
            var headerTableCellTextboxStyle = new StyleType();
            headerTableCellTextboxStyle.Items = new object[]
                                                    {
                                                        "700",
                                                        "10pt",
                                                        CreateTableCellTextboxBorderColorStyle(),
                                                        CreateTableCellTextboxBorderStyleStyle(),
                                                        CreateTableCellTextboxBorderWidthStyle(),
                                                        "2pt",
                                                        "2pt",
                                                        "2pt",
                                                        "2pt",
                                                        "Middle",
                                                    };
            headerTableCellTextboxStyle.ItemsElementName = new[]
                                                               {
                                                                   ItemsChoiceType5.FontWeight,
                                                                   ItemsChoiceType5.FontSize,
                                                                   ItemsChoiceType5.BorderColor,
                                                                   ItemsChoiceType5.BorderStyle,
                                                                   ItemsChoiceType5.BorderWidth,
                                                                   ItemsChoiceType5.PaddingTop,
                                                                   ItemsChoiceType5.PaddingBottom,
                                                                   ItemsChoiceType5.PaddingLeft,
                                                                   ItemsChoiceType5.PaddingRight,
                                                                   ItemsChoiceType5.VerticalAlign,
                                                               };
            return headerTableCellTextboxStyle;
        }

        private DetailsType CreateDetails()
        {
            var details = new DetailsType();
            details.Items = new object[] {CreateTableRows()};
            return details;
        }

        private TableRowsType CreateTableRows()
        {
            var tableRows = new TableRowsType();
            tableRows.TableRow = new[] {CreateTableRow()};
            return tableRows;
        }

        private TableRowType CreateTableRow()
        {
            var tableRow = new TableRowType();
            tableRow.Items = new object[] {CreateTableCells(), "0.6cm"};
            return tableRow;
        }

        private TableCellsType CreateTableCells()
        {
            var tableCells = new TableCellsType();
            tableCells.TableCell = new TableCellType[m_fields.Count];
            for (int i = 0; i < m_fields.Count; i++)
            {
                tableCells.TableCell[i] = CreateTableCell(m_fields[i]);
            }
            return tableCells;
        }

        private TableCellType CreateTableCell(ReportColumn field)
        {
            var tableCell = new TableCellType();
            tableCell.Items = new object[] {CreateTableCellReportItems(field)};
            return tableCell;
        }

        private ReportItemsType CreateTableCellReportItems(ReportColumn field)
        {
            var reportItems = new ReportItemsType();
            reportItems.Items = new object[] {CreateTableCellTextbox(field)};
            return reportItems;
        }

        private TextboxType CreateTableCellTextbox(ReportColumn field)
        {
            string fieldValue = "Fields!" + field.Name + ".Value";

            var textbox = new TextboxType();
            textbox.Name = field.Name;
            if (field.Name == "RowNumber")
            {
                textbox.Items = new object[]
                                    {
                                        "=RowNumber()",
                                        CreateTableCellTextboxStyle(),
                                        true,
                                    };
            }
            else
            {
                textbox.Items = new object[]
                                    {
                                        "=IIf(" + fieldValue + " = \"1\", \"Plaèal\", " +
                                        "IIf(" + fieldValue + " = \"2\", \"Ni plaèal\", " +
                                        "IIf(" + fieldValue + " = \"3\", \"Veteran\", " +
                                        "IIf(" + fieldValue + " = \"4\", \"Mladoletnik\", " +
                                        "IIf(" + fieldValue + " = \"5\", \"Ni podatka\", " + fieldValue + ")))))",
                                        CreateTableCellTextboxStyle(),
                                        true,
                                    };
            }
            textbox.ItemsElementName = new[]
                                           {
                                               ItemsChoiceType14.Value,
                                               ItemsChoiceType14.Style,
                                               ItemsChoiceType14.CanGrow,
                                           };
            return textbox;
        }

        private StyleType CreateTableCellTextboxStyle()
        {
            var style = new StyleType();
            style.Items = new object[]
                              {
                                  //"=iif(RowNumber(Nothing) mod 2, \"AliceBlue\", \"White\")",
                                  "Left",
                                  "8pt",
                                  CreateTableCellTextboxBorderColorStyle(),
                                  CreateTableCellTextboxBorderStyleStyle(),
                                  CreateTableCellTextboxBorderWidthStyle(),
                                  "2pt",
                                  "2pt",
                                  "2pt",
                                  "2pt",
                                  "Middle"
                              };
            style.ItemsElementName = new[]
                                         {
                                             //Rdl.ItemsChoiceType5.BackgroundColor,
                                             ItemsChoiceType5.TextAlign,
                                             ItemsChoiceType5.FontSize,
                                             ItemsChoiceType5.BorderColor,
                                             ItemsChoiceType5.BorderStyle,
                                             ItemsChoiceType5.BorderWidth,
                                             ItemsChoiceType5.PaddingTop,
                                             ItemsChoiceType5.PaddingBottom,
                                             ItemsChoiceType5.PaddingLeft,
                                             ItemsChoiceType5.PaddingRight,
                                             ItemsChoiceType5.VerticalAlign
                                         };
            return style;
        }

        private BorderColorStyleWidthType CreateTableCellTextboxBorderColorStyle()
        {
            var border = new BorderColorStyleWidthType();
            border.Items = new object[]
                               {
                                   "Black"
                               };
            border.ItemsElementName = new[]
                                          {
                                              ItemsChoiceType3.Default
                                          };

            return border;
        }

        private BorderColorStyleWidthType CreateTableCellTextboxBorderStyleStyle()
        {
            var border = new BorderColorStyleWidthType();
            border.Items = new object[]
                               {
                                   "Solid"
                               };
            border.ItemsElementName = new[]
                                          {
                                              ItemsChoiceType3.Default
                                          };

            return border;
        }

        private BorderColorStyleWidthType CreateTableCellTextboxBorderWidthStyle()
        {
            var border = new BorderColorStyleWidthType();
            border.Items = new object[]
                               {
                                   "1pt"
                               };
            border.ItemsElementName = new[]
                                          {
                                              ItemsChoiceType3.Default
                                          };

            return border;
        }

        private TableColumnsType CreateTableColumns()
        {
            var tableColumns = new TableColumnsType();
            tableColumns.TableColumn = new TableColumnType[m_fields.Count];
            for (int i = 0; i < m_fields.Count; i++)
            {
                tableColumns.TableColumn[i] = CreateTableColumn(m_fields[i].Width);
            }
            return tableColumns;
        }

        private TableColumnType CreateTableColumn(string width)
        {
            var tableColumn = new TableColumnType();
            tableColumn.Items = new object[] {width};
            return tableColumn;
        }
    }
}