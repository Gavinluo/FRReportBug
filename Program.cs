using System;
using System.Data;

namespace FR2022ReportBug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextLostWordsWithBlodStyle();
        }
        /// <summary>
        /// https://support.fast-report.com/tickets/681008
        /// </summary>
        public static void TextLostWordsWithBlodStyle()
        {
            var fReport = new FastReport.Report();
            fReport.Report.Load("TextLostWordsWithBlodStyle.frx");
            fReport.Prepare();
            var exportPdf = new FastReport.Export.Pdf.PDFExport();
            exportPdf.SetReport(fReport);
            exportPdf.Compressed = true;
            exportPdf.Background = false;
            exportPdf.PrintOptimized = false;
            exportPdf.EmbeddingFonts = true;
            exportPdf.OpenAfterExport = false;
            string filename = $"A-TextLostWordsWithBlodStyle-{DateTime.Now.ToString("HH-mm-ss")}.pdf";
            fReport.Export(exportPdf, filename);
        }
        /// <summary>
        /// https://support.fast-report.com/tickets/681003
        /// </summary>
        public static void ImageDisplayIncorrectly()
        {
            var fReport = new FastReport.Report();
            fReport.Report.Load("ImageDisplayIncorrectly.frx");
            fReport.Prepare();
            var exportPdf = new FastReport.Export.Pdf.PDFExport();
            exportPdf.SetReport(fReport);
            exportPdf.Compressed = true;
            exportPdf.Background = false;
            exportPdf.PrintOptimized = false;
            exportPdf.EmbeddingFonts = true;
            exportPdf.OpenAfterExport = false;
            string filename = $"A-ImageDisplayIncorrectly-{DateTime.Now.ToString("HH-mm-ss")}.pdf";
            fReport.Export(exportPdf, filename);
            var exportExcel = new FastReport.Export.OoXML.Excel2007Export();
            exportExcel.SetReport(fReport);
            exportExcel.PrintOptimized = false;
            exportExcel.OpenAfterExport = false;
            filename = $"A-ImageDisplayIncorrectly-{DateTime.Now.ToString("HH-mm-ss")}.xls";
            fReport.Export(exportExcel, filename);
        }
        /// <summary>
        /// https://support.fast-report.com/tickets/680985
        /// </summary>
        public static void BarcodeTextDisplayIncorrectly()
        {
            var fReport = new FastReport.Report();
            fReport.Report.Load("BarcodeTextBug.frx");
            fReport.Prepare();
            var exportPdf = new FastReport.Export.Pdf.PDFExport();
            exportPdf.SetReport(fReport);
            exportPdf.OpenAfterExport = false;
            string filename = $"A-BarcodeTextBug-{DateTime.Now.ToString("HH-mm-ss")}.pdf";
            fReport.Export(exportPdf, filename);
        }
        /// <summary>
        /// https://support.fast-report.com/tickets/680982
        /// </summary>
        public static void TestRichTextDisplayIncorrectly()
        {
            var fReport = new FastReport.Report();
            fReport.Report.Load("RichTextDemo.frx");
            DataSet ds = new DataSet("Table1");
            DataTable dt = new DataTable("Table1");
            dt.Columns.Add("CREATED_DATE", typeof(DateTime));
            dt.Rows.Add(DateTime.Now);
            ds.Tables.Add(dt);
            fReport.RegisterData(ds);
            fReport.Prepare();
            var exportPdf = new FastReport.Export.Pdf.PDFExport();
            exportPdf.SetReport(fReport);
            exportPdf.Compressed = false;
            exportPdf.Background = false;
            exportPdf.PrintOptimized = false;
            exportPdf.OpenAfterExport = false;
            string filename = DateTime.Now.ToString("MM-dd-HH-mm-ss") + ".pdf";
            fReport.Export(exportPdf, filename);
        }
        /// <summary>
        /// https://support.fast-report.com/tickets/680360
        /// </summary>
        public static void TestDateFormat()
        {
            var fReport = new FastReport.Report();
            fReport.Report.Load("DatetimeFormatBug.frx");
            DataSet ds = new DataSet("Table1");
            DataTable dt = new DataTable("Table1");
            dt.Columns.Add("CREATED_DATE", typeof(DateTime));
            dt.Rows.Add(DateTime.Now);
            ds.Tables.Add(dt);
            fReport.RegisterData(ds);
            fReport.Prepare();
            var exportPdf = new FastReport.Export.Pdf.PDFExport();
            exportPdf.SetReport(fReport);
            exportPdf.Compressed = false;
            exportPdf.Background = false;
            exportPdf.PrintOptimized = false;
            exportPdf.OpenAfterExport = false;
            string filename = DateTime.Now.ToString("MM-dd-HH-mm-ss") + ".pdf";
            fReport.Export(exportPdf, filename);
        }
        /// <summary>
        /// https://support.fast-report.com/tickets/678371
        /// </summary>
        public static void TestNumberChinese()
        {
            var fReport = new FastReport.Report();
            fReport.Report.Load("NumberChineseDemo.frx");
            DataSet ds = new DataSet("Table1");
            DataTable dt = new DataTable("Table1");
            dt.Columns.Add("ZWEIGHT", typeof(String));
            dt.Columns.Add("ZVOLUME", typeof(String));
            dt.Rows.Add("207.000000", "907.344000");
            ds.Tables.Add(dt);
            fReport.RegisterData(ds);
            fReport.Prepare();
            var exportPdf = new FastReport.Export.Pdf.PDFExport();
            exportPdf.SetReport(fReport);
            exportPdf.Compressed = true;
            exportPdf.Background = false;
            exportPdf.PrintOptimized = false;
            exportPdf.OpenAfterExport = false;
            string filename = DateTime.Now.ToString("MM-dd-HH-mm-ss") + ".pdf";
            fReport.Export(exportPdf, filename);
        }
    }
}
