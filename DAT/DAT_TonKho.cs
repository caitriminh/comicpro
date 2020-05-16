using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class DatTonKho : DbConnect
    {
        public DataTable GetTonKho(int option, int thang, int nam, string duongdanhinh, string matua)
        {
            DataTable dt = new DataTable();
            LoadDataProc("pro_get_tonkho", ref dt, new SqlParameter("@option", option), new SqlParameter("@thang", thang), new SqlParameter("@nam", nam), new SqlParameter("@duongdanhinh", duongdanhinh), new SqlParameter("@matua", matua));
            return dt;
        }

        public bool Delete(int thang, int nam)
        {
            Connection.Open();
            var cmd = new SqlCommand($"DELETE FROM dbo.tbl_tonkho WHERE MONTH(ky)='{thang}' AND YEAR(ky)='{nam}'", Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            return true;
        }

        public bool ChuyenSoDu(string ky)
        {
            ExecuteProcNonQuery("pro_chuyensodu", new SqlParameter("@ky", ky));
            return true;
        }

        public DataTable GetTuaTruyen()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT b.matua, c.tuatruyen FROM dbo.tbl_tonkho a INNER JOIN dbo.tbl_tentruyen b ON b.matruyen = a.matruyen INNER JOIN dbo.tbl_tuatruyen c ON c.matua=b.matua WHERE MONTH(ky)=MONTH(GETDATE()) AND YEAR(ky)=YEAR(GETDATE()) ORDER BY c.tuatruyen", Connection);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetGiaTri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 12 MONTH(ngaynhap) AS thang, YEAR(ngaynhap) AS nam, CONCAT(N'Tháng ',FORMAT(MONTH(ngaynhap),'00'),'-', YEAR(ngaynhap)) AS thangnam, SUM(slnhap * dongia) AS thanhtien FROM dbo.tbl_phieunhapxuat GROUP BY MONTH(ngaynhap), YEAR(ngaynhap) ORDER BY YEAR(ngaynhap), MONTH(ngaynhap)", Connection);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetTong()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(slnhap*dongia) AS tong FROM dbo.tbl_phieunhapxuat", Connection);
            da.Fill(dt);
            return dt;
        }
    }
}
