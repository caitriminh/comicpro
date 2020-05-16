using Dapper.Contrib.Extensions;

namespace ComicPro2019
{
    [Table("tbl_nhomdonvi")]
    internal class NhomDonVi
    {
        [ExplicitKey]
        public int id { get; set; }

        public string nhomdonvi { get; set; }
    }
}
