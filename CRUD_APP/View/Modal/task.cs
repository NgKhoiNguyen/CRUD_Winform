using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using framework.core_app;
namespace framework.View.Modal
{
    [Table("tasks")]
    public class tasks : BaseEntity
    {
        [ExplicitKey]
        public string Id { set; get; }
        public string title { set; get; }
        public string description { set; get; }
        public string status { set; get; }
        public DateTime created_at { set; get; }
        public DateTime updated_at { set; get; }

    }
}
