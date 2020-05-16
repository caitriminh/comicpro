using Dapper.Contrib.Extensions;
using System;

namespace ComicPro2019
{
    [Table("tbl_nhaxuatban")]
    internal class NXB
    {
        [ExplicitKey]
        public string manxb { get; set; }

        public string nhaxuatban { get; set; }

        public string diachi { get; set; }

        public string sodt { get; set; }

        public string sofax { get; set; }

        public string ghichu { get; set; }

        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }
    }
}
