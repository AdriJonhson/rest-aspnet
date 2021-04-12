using System;
using RestWithAspNET.Models;

namespace RestWithAspNET.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        public CategoryVO Category { get; set; }
        
        public DateTime LaunchDate { get; set; }
    }
}