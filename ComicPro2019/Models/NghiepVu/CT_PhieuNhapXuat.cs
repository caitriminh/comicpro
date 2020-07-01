using Dapper.Contrib.Extensions;
using System;

namespace ComicPro2019
{
    [Table("tbl_ct_phieunhapxuat")]
    internal class CT_PhieuNhapXuat
    {
        [Key]
        public int id { get; set; }

        public string maphieu { get; set; }

        public string matruyen { get; set; }

        public int? slnhap { get; set; }

        public int? slxuat { get; set; }

        public float? dongia { get; set; }

        public string ghichu { get; set; }


        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }
    }
}
