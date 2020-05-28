using Dapper.Contrib.Extensions;

namespace ComicPro2019
{
    [Table("tbl_thongtin")]
    internal class ThongTin
    {
        [Key]
        public int id { get; set; }

        public string tencuahang { get; set; }

        public string diachi { get; set; }

        public string tinhthanh { get; set; }

        public string quanhuyen { get; set; }

        public string email { get; set; }

        public string sodt { get; set; }

        public string web { get; set; }
    }
}
