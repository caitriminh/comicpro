using Dapper.Contrib.Extensions;
using System;

namespace ComicPro2019
{
    [Table("tbl_kho")]
    internal class Kho
    {
        [ExplicitKey]
        public string makho { get; set; }

        public string tenkho { get; set; }

        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }
    }
}
