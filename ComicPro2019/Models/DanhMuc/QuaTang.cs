using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicPro2019.Models.DanhMuc
{
    [Table("tbl_quatang")]
    internal class QuaTang
    {
        [ExplicitKey]
        public string maquatang { get; set; }

        public string quatang { get; set; }

        public string ghichu { get; set; }

        public string nguoitd { get; set; }
        [Write(false)]
        public DateTime? thoigian { get; set; }

        public string nguoitd2 { get; set; }

        public DateTime? thoigian2 { get; set; }
    }
}
