using Dapper.Contrib.Extensions;
using System;

namespace ComicPro2019
{
    [Table("tbl_user")]
    internal class User
    {
        [ExplicitKey]
        public string tendangnhap { get; set; }

        public string hoten { get; set; }

        public string matkhau { get; set; }

        public string ghichu { get; set; }

        public bool? truycap { get; set; }

        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }
    }
}
