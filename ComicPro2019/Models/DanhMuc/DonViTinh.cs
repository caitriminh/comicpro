using Dapper.Contrib.Extensions;
using System;

namespace ComicPro2019
{
    [Table("tbl_donvitinh")]
    internal class DonViTinh
    {
        [Key]
        public int id { get; set; }

        public string donvitinh { get; set; }

        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }
    }
}
