using System;
using Dapper.Contrib.Extensions;
using framework.core_app;
namespace framework.View.Modal
{
    [Table("Product")]
    public class product:BaseEntity
    {
        [ExplicitKey]
        public string Id { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public string Category { set; get; }
        public DateTime CreatedAt { set; get; }
        public DateTime UpdatedAt { set; get; }
    }
}
