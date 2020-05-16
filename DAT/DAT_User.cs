using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class DatUser : DbConnect
    {
        public DataTable GetUser()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.tbl_user where tendangnhap<>'admin'", Connection);
            da.Fill(dt);
            return dt;
        }

        public int CheckId(string tendangnhap)
        {
            Connection.Open();
            var cmd = new SqlCommand($"SELECT COUNT(*) FROM dbo.tbl_user WHERE tendangnhap='{tendangnhap}'", Connection);
            var i = Convert.ToInt32(cmd.ExecuteScalar());
            Connection.Close();
            return i;
        }
        public bool Insert(DtoUser dtoUser)
        {
            ExecuteProcNonQuery("pro_insert_user", new SqlParameter("@tendangnhap", dtoUser.Tendangnhap), new SqlParameter("@matkhau", dtoUser.Matkhau), new SqlParameter("@ghichu", dtoUser.Ghichu), new SqlParameter("@nguoitd", dtoUser.Nguoitd), new SqlParameter("@hoten", dtoUser.Hoten));
            return true;
        }

        public bool Update(DtoUser dtoUser)
        {
            ExecuteProcNonQuery("pro_update_user", new SqlParameter("@tendangnhap", dtoUser.Tendangnhap),
                 new SqlParameter("@ghichu", dtoUser.Ghichu), new SqlParameter("@nguoitd2", dtoUser.Nguoitd2), new SqlParameter("@hoten", dtoUser.Hoten), new SqlParameter("@truycap", dtoUser.Truycap));
            return true;
        }
        public int DangNhap(string tendangnhap, string matkhau)
        {
            Connection.Open();
            var cmd = new SqlCommand($"SELECT COUNT(*) FROM dbo.tbl_user WHERE tendangnhap='{tendangnhap}' AND matkhau=CONVERT(VARCHAR(32), HashBytes('MD5', '{matkhau}'), 2)", Connection);
            var i = Convert.ToInt32(cmd.ExecuteScalar());
            Connection.Close();
            return i;
        }

        public bool Delete(string tendangnhap)
        {
            Connection.Open();
            var cmd = new SqlCommand($"DELETE FROM dbo.tbl_user WHERE tendangnhap='{tendangnhap}'", Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            return true;
        }

        public bool ResetPass(string tendangnhap)
        {
            Connection.Open();
            var cmd = new SqlCommand($"UPDATE dbo.tbl_user SET matkhau=CONVERT(VARCHAR(32), HashBytes('MD5', tendangnhap), 2) WHERE tendangnhap='{tendangnhap}'", Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            return true;
        }

        public bool DoiMatKhau(string tendangnhap, string matkhau)
        {
            Connection.Open();
            var cmd = new SqlCommand($"UPDATE dbo.tbl_user SET matkhau=CONVERT(VARCHAR(32), HashBytes('MD5', '{matkhau}'), 2) WHERE tendangnhap='{tendangnhap}'", Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            return true;
        }
    }
}
