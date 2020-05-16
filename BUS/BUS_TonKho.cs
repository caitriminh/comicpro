using System.Data;
using DAT;

namespace BUS
{
    public class BusTonKho
    {
        DatTonKho _datTonKho = new DatTonKho();

        public DataTable GetTonKho(int option, int thang, int nam, string duongdanhinh, string matua)
        {
            return _datTonKho.GetTonKho(option, thang, nam, duongdanhinh, matua);
        }

        public bool Delete(int thang, int nam)
        {
            return _datTonKho.Delete(thang, nam);
        }

        public bool ChuyenSoDu(string ky)
        {
            return _datTonKho.ChuyenSoDu(ky);
        }

        public DataTable GetTuaTruyen()
        {
            return _datTonKho.GetTuaTruyen();
        }

        public DataTable GetGiaTri()
        {
            return _datTonKho.GetGiaTri();
        }

        public DataTable GetTong()
        {
            return _datTonKho.GetTong();
        }
    }
}
