using System;
using Dapper.Contrib.Extensions;

using framework.core_app;
namespace framework.View.Modal
{
    [Table("San_Pham")]
    public class san_pham:BaseEntity
    {
        [ExplicitKey]
        public string Id { set; get; }
        public string tensp { set; get; }
        public string ngaysx { set; get; }
        public float dongia { set; get; }
    }
}
