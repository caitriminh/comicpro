using System;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class DatLoaiTruyen : DbConnect
    {
        public DataTable GetLoaiTruyen()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.tbl_loaitruyen", Connection);
            da.Fill(dt);
            return dt;
        }

        public bool Delete(string maloai)
        {
            Connection.Open();
            var cmd = new SqlCommand($"DELETE FROM dbo.tbl_loaitruyen WHERE maloai='{maloai}'", Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            return true;
        }

        public bool Insert(DtoLoaiTruyen dtoLoaiTruyen)
        {
            ExecuteProcNonQuery("pro_insert_loaitruyen", new SqlParameter("@loaitruyen", dtoLoaiTruyen.Loaitruyen),
                new SqlParameter("@nguoitd", dtoLoaiTruyen.Nguoitd), new SqlParameter("@maloai", dtoLoaiTruyen.Maloai));
            return true;
        }

        public bool Update(DtoLoaiTruyen dtoLoaiTruyen)
        {
            ExecuteProcNonQuery("pro_update_loaitruyen", new SqlParameter("@loaitruyen", dtoLoaiTruyen.Loaitruyen),
                new SqlParameter("@nguoitd2", dtoLoaiTruyen.Nguoitd2), new SqlParameter("@maloai", dtoLoaiTruyen.Maloai));
            return true;
        }

        public int CheckId(string maloai)
        {
            Connection.Open();
            var cmd = new SqlCommand($"SELECT COUNT(*) FROM dbo.tbl_loaitruyen WHERE maloai='{maloai}'", Connection);
            var i = Convert.ToInt32(cmd.ExecuteScalar());
            Connection.Close();
            return i;
        }

        public DataTable GetTongSoLoaiTruyen()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT b.maloai, c.loaitruyen, COUNT(*) AS soluong FROM dbo.tbl_tentruyen a INNER JOIN dbo.tbl_tuatruyen b ON b.matua = a.matua INNER JOIN dbo.tbl_loaitruyen c ON c.maloai = b.maloai GROUP BY b.maloai, c.loaitruyen", Connection);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetTongSo()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(DISTINCT matruyen) AS tong FROM dbo.tbl_phieunhapxuat WHERE slnhap>0", Connection);
            da.Fill(dt);
            return dt;
        }
    }
}
