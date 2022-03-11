using System;
using System.Data;

namespace FR2022ReportBug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestDateFormat();
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
