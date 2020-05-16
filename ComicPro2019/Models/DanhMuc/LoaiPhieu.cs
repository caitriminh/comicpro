using Dapper.Contrib.Extensions;

namespace ComicPro2019
{
    [Table("tbl_loaiphieunhapxuat")]
    internal class LoaiPhieu
    {
        [ExplicitKey]
        public int id { get; set; }

        public string loaiphieu { get; set; }
    }
}
