using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class DatThongTin : DbConnect
    {
        public DataTable GetThongTin()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.tbl_thongtin", Connection);
            da.Fill(dt);
            return dt;
        }

        public bool Insert(string tencuahang, string diachi, string tinhthanh, string quanhuyen, string email, string sodt, string web)
        {
            ExecuteProcNonQuery("pro_insert_thongtin", new SqlParameter("@tencuahang", tencuahang), new SqlParameter("@diachi", diachi), new SqlParameter("@tinhthanh", tinhthanh), new SqlParameter("@quanhuyen", quanhuyen), new SqlParameter("@email", email), new SqlParameter("@sodt", sodt), new SqlParameter("@web", web));
            return true;
        }
    }
}
