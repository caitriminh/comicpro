using Dapper.Contrib.Extensions;
using System;

namespace ComicPro2019
{
    [Table("tbl_loaitruyen")]
    internal class LoaiTruyen
    {
        [ExplicitKey]
        public string maloai { get; set; }

        public string loaitruyen { get; set; }

        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }
    }
}
