using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAT;
using DTO;

namespace BUS
{
    public class BusUser
    {
        DatUser _datUser = new DatUser();

        public DataTable GetUser()
        {
            return _datUser.GetUser();
        }

        public int CheckId(string tendangnhap)
        {
            return _datUser.CheckId(tendangnhap);
        }

        public bool Insert(DtoUser dtoUser)
        {
            return _datUser.Insert(dtoUser);
        }

        public int DangNhap(string tendangnhap, string matkhau)
        {
            return _datUser.DangNhap(tendangnhap, matkhau);
        }

        public bool Delete(string tendangnhap)
        {
            return _datUser.Delete(tendangnhap);
        }

        public bool Update(DtoUser dtoUser)
        {
            return _datUser.Update(dtoUser);
        }

        public bool ResetPass(string tendangnhap)
        {
            return _datUser.ResetPass(tendangnhap);
        }

        public bool DoiMatKhau(string tendangnhap, string matkhau)
        {
            return _datUser.DoiMatKhau(tendangnhap, matkhau);
        }
    }
}
