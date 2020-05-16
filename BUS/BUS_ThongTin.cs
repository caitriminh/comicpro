using System.Data;
using DAT;

namespace BUS
{
    public class BusThongTin
    {
        DatThongTin _datThongTin = new DatThongTin();

        public DataTable GetThongTin()
        {
            return _datThongTin.GetThongTin();
        }

        public bool Insert(string tencuahang, string diachi, string tinhthanh, string quanhuyen, string email, string sodt, string web)
        {
            return _datThongTin.Insert(tencuahang, diachi, tinhthanh, quanhuyen, email, sodt, web);
        }
    }
}
