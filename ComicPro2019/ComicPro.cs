using ComicPro2019.HeThong;
using DevExpress.XtraEditors;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace ComicPro2019
{
    internal sealed class ComicPro
    {
        public static string StrTenDangNhap = "ADMIN";
        public static string StrMaphieu, StrMaTacGia, StrThoiGianDangNhap, StrDuongDanPdf, StrCaption, StrMaTua, StrMaTruyen;
        public static bool Edit;
        public static int Report;
        public static DataTable DtReport;
        public static string URL_HinhAnh = "http://triminh.xyz/img/thumb/";
        public static string TEMP_PATH = Path.GetTempPath() + Assembly.GetExecutingAssembly().GetName().Name + "\\";
        public static void ExportExcelFromDataTable(DataTable table, string fullPathFileName, string sheetName = "Sheet 1", string writeBeginCell = "A2", string passwordFile = "", bool isPrintHeader = true, bool isOpenFileExcel = true)
        {
            if (table.Rows.Count <= 0)
            {
                Form1.Default.ShowMessageWarning($"Không tìm thấy dữ liệu.");
                return;
            }

            if (File.Exists(fullPathFileName))
            {
                Form1.Default.ShowMessageWarning($"Tên file {Path.GetFileName(fullPathFileName)} đã tồn tại! Đặt lại tên khác!");
                return;
            }

            var fileInfo = new FileInfo(Path.GetFileName(fullPathFileName));
            using (ExcelPackage pck = new ExcelPackage(fileInfo, passwordFile))
            {
                pck.Workbook.Properties.Author = ComicPro.StrTenDangNhap.ToUpper();
                pck.Workbook.Properties.Company = "COMICPRO";
                pck.Workbook.Properties.Title = "Exported by COMICPRO";
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(sheetName);
                ws.Cells[writeBeginCell].LoadFromDataTable(table, isPrintHeader);
                pck.Save(passwordFile);
            }

            if (isOpenFileExcel)
            {
                //  Process.Start(fullPathFileName);
                var frm = new FrmViewExcel(fullPathFileName);
                frm.Show();
            }
        }

        public static bool IsValidUri(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute)) { return false; }

            Uri tmp;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out tmp)) { return false; }

            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }

        public static bool OpenUri(string uri)
        {
            if (!IsValidUri(uri)) { return false; }

            System.Diagnostics.Process.Start(uri);
            return true;
        }

        public static byte[] EncryptData(string data)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }

        public static string Md5(string data)
        {
            return BitConverter.ToString(EncryptData(data)).Replace("-", "").ToLower();
        }

    }


}
