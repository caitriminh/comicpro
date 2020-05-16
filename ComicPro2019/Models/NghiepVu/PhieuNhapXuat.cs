using Dapper.Contrib.Extensions;
using System;

namespace ComicPro2019
{
    [Table("tbl_phieunhapxuat")]
    internal class PhieuNhapXuat
    {
        [Key]
        public int id { get; set; }

        public string maphieu { get; set; }

        public string madonvi { get; set; }

        public string loaiphieu { get; set; }

        public int? idloaiphieunhapxuat { get; set; }

        public DateTime? ngaynhap { get; set; }

        public string nguoilap { get; set; }

        public string makho { get; set; }

        public string matruyen { get; set; }

        public int? slnhap { get; set; }

        public int? slxuat { get; set; }

        public float? dongia { get; set; }

        public string ghichu { get; set; }

        public string diengiai { get; set; }

        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }
    }
}
