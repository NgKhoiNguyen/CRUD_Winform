using System;
using framework.core_app;
using Dapper.Contrib.Extensions;
namespace framework.View.Modal
{
    [Table("users")]
    public class users:IAuthBase
    {
        [ExplicitKey]
        public string Id { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string name { set; get; }
    }
}
