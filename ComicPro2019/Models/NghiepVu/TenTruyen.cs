using Dapper.Contrib.Extensions;
using System;

namespace ComicPro2019
{
    [Table("tbl_tentruyen")]
    internal class TenTruyen
    {
        [Write(false)]
        public string tinhtrang { get; set; }
        [ExplicitKey]
        public string matruyen { get; set; }

        public string tentruyen { get; set; }
        [Write(false)]
        public string loaitruyen { get; set; }

        public int? madvt { get; set; }
        [Write(false)]
        public string donvitinh { get; set; }
        public string matua { get; set; }
        [Write(false)]
        public string tuatruyen { get; set; }

        public int? maloaibia { get; set; }
        [Write(false)]
        public string loaibia { get; set; }
        public int? tap { get; set; }

        public decimal? giabia { get; set; }
        public string maquatang { get; set; }

        public DateTime? ngayxuatban { get; set; }
        [Write(false)]
        public string nhaxuatban { get; set; }
        public int? sotrang { get; set; }
        [Write(false)]
        public int? taiban { get; set; }
        public string ghichu { get; set; }
        [Write(false)]
        public string tacgia { get; set; }
        [Write(false)]
        public string quocgia { get; set; }

        public bool? sohuu { get; set; }

        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }

        public string hinhanh { get; set; }
        [Write(false)]
        public string uploadfile { get; set; }
        [Write(false)]
        public string progress { get; set; }
        [Write(false)]
        public string doctruyen { get; set; }

        public int? id { get; set; }

        public bool? filetruyen { get; set; }

        public string fileid { get; set; }

    }
}
