using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNET.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}