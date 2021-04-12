using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithAspNET.Models.Base;

namespace RestWithAspNET.Models
{
    [Table("categories")]
    public class Category : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }
    }
}