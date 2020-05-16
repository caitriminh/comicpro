namespace DTO
{
    public class DtoUser
    {
        public DtoUser(string tendangnhap, string matkhau, string hoten, bool truycap, string ghichu, string nguoitd, string nguoitd2)
        {
            Tendangnhap = tendangnhap;
            Matkhau = matkhau;
            Hoten = hoten;
            Truycap = truycap;
            Ghichu = ghichu;
            Nguoitd = nguoitd;
            Nguoitd2 = nguoitd2;
        }
        public string Tendangnhap { get; set; }
        public string Matkhau { get; set; }
        public string Hoten { get; set; }
        public bool Truycap { get; set; }
        public string Ghichu { get; set; }
        public string Nguoitd { get; set; }
        public string Nguoitd2 { get; set; }
    }
}
