using Dapper.Contrib.Extensions;
using System;

namespace ComicPro2019
{
    [Table("tbl_tuatruyen")]
    internal class TuaTruyen
    {
        [Write(false)]
        public string tinhtrang { get; set; }
        [ExplicitKey]
        public string matua { get; set; }

        public string tuatruyen { get; set; }

        public string maloai { get; set; }

        public int? maquocgia { get; set; }

        public int? sotap { get; set; }

        public string manxb { get; set; }

        public string matacgia { get; set; }

        public int? namxuatban { get; set; }

        public int? taiban { get; set; }

        public bool? theodoi { get; set; }

        public string ghichu { get; set; }

        public string folderid { get; set; }

        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }
    }
}
