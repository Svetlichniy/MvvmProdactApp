using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MvvmProdactApp.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace MvvmProdactApp.Services
{
    internal class ECNbuilder
    {
        private List<ObjStructure> Data { get; set; }
        private Font DocFont { get { return GetDocFont(); } }
        private PdfPTable  table { get; set; }

        private readonly float PageHeight = 820;
        private readonly float headerHeight = 40f;

        private readonly int FirstPageMaxRows = 26;
        private readonly int NextPageMaxRows = 28;


        public ECNbuilder(ObservableCollection<ObjStructure> structure)
        {
            Data = structure.ToList();
        }
        
        public void BuildECN()
        {
            var fs = new FileStream(@"First ECN.pdf", FileMode.Create);
            Document document = new Document(PageSize.A4, 10, 10, 10, 10);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //main table
            table = new PdfPTable(3) { SplitLate = false, SplitRows = true };
            table.TotalWidth = 570f;
            table.LockedWidth = true;
            table.SetWidths(new float[] { 28.5f, 42f, 499.5f });
            table.HorizontalAlignment = Element.ALIGN_RIGHT;


            //---
            var ResultList = new List<string[]>();
            var NextList = new List<string[]>();

            //Раздел док-ции
            AddECNsection(ResultList, "Документация");
            ResultList.Add(new string[7] { "", "", "", "", "СБорочный чертеж", "", "" });

            AddSectionData(ResultList, "Сборочная единица");
            AddSectionData(ResultList, "Деталь");
            AddSectionData(ResultList, "Стандартное изделие");

            GeneratePage(ResultList, NextList, true);
            
                        
            #region StartPdf
            document.Add(table);
            document.Close();
            fs.Close();

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(@"First ECN.pdf")
            {
                UseShellExecute = true
            };
            p.Start();
            #endregion
        }

        private void GeneratePage(List<string[]> ResultList, List<string[]> NextList, bool firstPage)
        {
            if (ResultList.Count < FirstPageMaxRows && firstPage)
            {
                int needRows = FirstPageMaxRows - ResultList.Count;
                for (int j = 0; j < needRows; j++)
                    AddEmptyRowToResultList(ResultList);
            }
            else if (ResultList.Count < NextPageMaxRows && !firstPage)
            {
                int needRows = NextPageMaxRows - ResultList.Count;
                for (int j = 0; j < needRows; j++)
                    AddEmptyRowToResultList(ResultList);
            }
            else
            {
                int countNext = 0;
                if (firstPage)
                    countNext = ResultList.Count - FirstPageMaxRows;
                else
                    countNext = ResultList.Count - NextPageMaxRows;
                NextList.AddRange(ResultList.GetRange(FirstPageMaxRows, countNext));
                ResultList.RemoveRange(FirstPageMaxRows, countNext);
            }

            AddPage(firstPage, table, ResultList);

            if (NextList.Count > 0)
                GeneratePage(NextList, new List<string[]>(), false);
        }

        private void AddPage(bool FirstPage, PdfPTable _table, List<string[]> resultList)
        {
            if (FirstPage)
            {
                //page 1 col1
                _table.AddCell(new PdfPCell(new Phrase(" ")) { FixedHeight = PageHeight, BorderWidth = 0 });
                //page 1 col2
                _table.AddCell(new PdfPCell(AdvancedLeftTable()) { FixedHeight = PageHeight, BorderWidth = 0 });
                //row 1 col3
                _table.AddCell(new PdfPCell(ContentStructure(true, resultList)) { FixedHeight = PageHeight, BorderWidth = 2 });
            }
            else
            {
                //page 2 col 1
                _table.AddCell(new PdfPCell(new Phrase(" ")) { FixedHeight = PageHeight, BorderWidth = 0 });
                //page 2 col 2
                _table.AddCell(new PdfPCell(AdvancedLeftTable()) { FixedHeight = PageHeight, BorderWidth = 0 });
                //page 2 col 3
                _table.AddCell(new PdfPCell(ContentStructure(false, resultList)) { FixedHeight = PageHeight, BorderWidth = 2 });
            }
        }

        private PdfPTable AdvancedLeftTable()
        {
            var LeftTable = new PdfPTable(2) { SplitLate = false, SplitRows = true };
            LeftTable.TotalWidth = 42f;
            LeftTable.LockedWidth = true;
            LeftTable.SetWidths(new float[] { 21f, 21f });
            LeftTable.HorizontalAlignment = Element.ALIGN_RIGHT;

            AddAdvancedCell("Перв. прим.", 162f, LeftTable);
            AddAdvancedCell("", 162f, LeftTable);

            AddAdvancedCell("Справ №", 162f, LeftTable);
            AddAdvancedCell("", 162f, LeftTable);

            AddAdvancedEmptyCell("", 94.5f, LeftTable);
            AddAdvancedEmptyCell("", 94.5f, LeftTable);

            AddAdvancedCell("Подп. и дата", 94.5f, LeftTable);
            AddAdvancedCell("", 94.5f, LeftTable);

            AddAdvancedCell("Инв №", 67.5f, LeftTable);
            AddAdvancedCell("", 67.5f, LeftTable);

            AddAdvancedCell("Взам инв №", 67.5f, LeftTable);
            AddAdvancedCell("", 67.5f, LeftTable);

            AddAdvancedCell("Подп. и дата", 94.5f, LeftTable);
            AddAdvancedCell("", 94.5f, LeftTable);

            AddAdvancedCell("Взам инв №", 67.5f, LeftTable);
            AddAdvancedCell("", 67.5f, LeftTable);

            return LeftTable;
        }

        private void AddAdvancedCell(string text, float height, PdfPTable leftTable)
        {
            leftTable.AddCell(new PdfPCell(new Phrase(text, DocFont)) 
            {
                Rotation = -90,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 2f,
                HorizontalAlignment = Element.ALIGN_CENTER,
                FixedHeight = height
            });
        }
        private void AddAdvancedEmptyCell(string text, float height, PdfPTable leftTable)
        {
            leftTable.AddCell(new PdfPCell(new Phrase(text, DocFont)) 
            {
                Rotation = -90,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                HorizontalAlignment = Element.ALIGN_CENTER,
                FixedHeight = height
            });
        }

        private PdfPTable ContentStructure(bool firstPage, List<string[]> resultList)
        {
            var StructTable = new PdfPTable(1) { SplitLate = false, SplitRows = true };
            StructTable.TotalWidth = 499.5f;
            StructTable.LockedWidth = true;
            StructTable.SetWidths(new float[] { 499.5f });
            StructTable.HorizontalAlignment = Element.ALIGN_RIGHT;

            if (firstPage)
            {
                StructTable.AddCell(new PdfPCell(ContentTable(FirstPageMaxRows, resultList)) { FixedHeight = 700, BorderWidth = 1 });
                StructTable.AddCell(new PdfPCell() { FixedHeight = 110f });

                return StructTable;
            }
            else
            {
                StructTable.AddCell(new PdfPCell(ContentTable(NextPageMaxRows, resultList)) { FixedHeight = 750.7f, BorderWidth = 1 });
                StructTable.AddCell(new PdfPCell() { FixedHeight = 59.3f });

                return StructTable;
            }
        }
        private PdfPTable ContentTable(int maxRows, List<string[]> resultList)
        {
            var ContenTable = new PdfPTable(7) { SplitLate = false, SplitRows = true };
            ContenTable.TotalWidth = 499.5f;
            ContenTable.LockedWidth = true;
            ContenTable.SetWidths(new float[] { 16.2f, 16.2f, 21.6f, 189f, 170f, 27f, 59.4f });
            ContenTable.HorizontalAlignment = Element.ALIGN_RIGHT;

            //FontForFormat
            var FormatCellFont = GetDocFont();
            FormatCellFont.Size = 10f;

            //Header
            AddRotateHeaderCell("Формат", FormatCellFont, ContenTable);
            AddRotateHeaderCell("Зона", DocFont, ContenTable);
            AddRotateHeaderCell("Поз.", DocFont, ContenTable);
            AddHeaderCell("Обозначение", DocFont, ContenTable);
            AddHeaderCell("Наименование", DocFont, ContenTable);
            AddRotateHeaderCell("Кол.", DocFont, ContenTable);
            AddHeaderCell("Примечание", DocFont, ContenTable);

            //Content
            AddDataRows(ContenTable, maxRows, resultList);

            return ContenTable;
        }
        private void AddDataRows(PdfPTable ContenTable, int maxRows, List<string[]> resultList)
        {
            //Результирующий цикл заполнения содержимого бланка
            for (int i = 0; i < maxRows; i++)
                AddContentRow(resultList[i], ContenTable);
        }

        //----resultList----
        private void AddEmptyRowToResultList(List<string[]> resultList)
        {
            resultList.Add(new string[7] { "", "", "", "", "", "", "" });
        }
        private void AddECNsection(List<string[]> resultList, string section)
        {
            AddEmptyRowToResultList(resultList);
            resultList.Add(new string[7] { "", "", "", "", section, "", "" });
        }
        private void AddSectionData(List<string[]> resultList, string SectionName)
        {
            var TargetItems = Data.Where(e => e.LinkToObj.ProdactObj.Props.Section.Name.Equals(SectionName));
            if (TargetItems.Count() > 0)
                AddECNsection(resultList, SectionName);

            foreach (var dat in TargetItems)
            {
                resultList.Add(new string[7]
                {
                    "",
                    "",
                    dat.Position.ToString(),
                    dat.LinkToObj.ProdactObj.Props.Designation,
                    dat.LinkToObj.ProdactObj.Name,
                    dat.Count.ToString(),
                    dat.Annotation
                });
            }
        }


        private void AddRotateHeaderCell(string text, Font cellfont, PdfPTable ContenTable)
        {
            ContenTable.AddCell(new PdfPCell(new Phrase(text, cellfont)) 
            { 
                FixedHeight = headerHeight,
                Rotation = -90, 
                VerticalAlignment = Element.ALIGN_MIDDLE, 
                BorderWidth = 2f,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
        }
        private void AddHeaderCell(string text, Font cellfont, PdfPTable ContenTable)
        {
            ContenTable.AddCell(new PdfPCell(new Phrase(text, cellfont)) 
            { 
                FixedHeight = headerHeight,
                VerticalAlignment = Element.ALIGN_MIDDLE, 
                BorderWidth = 2f,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
        }

        private void AddContentRow(string[] RowData, PdfPTable ContentTable)
        {
            foreach (var cel in RowData)
                AddContentCell(cel, ContentTable);
        }
        private void AddContentCell(string text, PdfPTable ContenTable)
        {
            ContenTable.AddCell(new PdfPCell(new Phrase(text, DocFont)) 
            { 
                FixedHeight = 25.35f,
                VerticalAlignment = Element.ALIGN_MIDDLE, 
                BorderWidth = 1.5f,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
        }

        private static Font GetDocFont()
        {
            BaseFont baseFont = BaseFont.CreateFont("c:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font font = new Font(baseFont);
            return font;
        }
        private void MergeExample(PdfPTable table)
        {
            // row 1 / cell 1 (merge)
            PdfPCell _c = new PdfPCell(new Phrase("SER. No"))
            {
                Rotation = -90,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                HorizontalAlignment = Element.ALIGN_CENTER,
                BorderWidth = 0,
                //Rowspan = 3
            };
            _c.FixedHeight = 100f;
            table.AddCell(_c);
        }

    }
}