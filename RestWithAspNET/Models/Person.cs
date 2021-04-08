using System.ComponentModel.DataAnnotations.Schema;
using RestWithAspNET.Models.Base;

namespace RestWithAspNET.Models
{
    [Table("peoples")]
    public class Person : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        
        [Column("last_name")]
        public string LastName { get; set; }
        
        [Column("address")]
        public string Address { get; set; }
        
        [Column("enabled")]
        public bool Enabled { get; set; }

        [Column("gender")]
        public string Gender { get; set; }
    }
}