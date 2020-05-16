using Dapper.Contrib.Extensions;
using System;

namespace ComicPro2019
{
    [Table("tbl_tacgia")]
    internal class TacGia
    {
        [ExplicitKey]
        public string matacgia { get; set; }

        public string tacgia { get; set; }

        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }
    }
}
