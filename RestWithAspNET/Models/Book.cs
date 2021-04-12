using System;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithAspNET.Models.Base;

namespace RestWithAspNET.Models
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("author")]
        public string Author { get; set; }
        
        [Column("price")]
        public double Price { get; set; }
        
        [Column("category_id")]
        [ForeignKey("Category")]
        public long? CategoryId { get; set; }
        public Category Category { get; set; }

        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
    }
}