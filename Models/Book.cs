﻿namespace Cozma_Laurentiu_Lab2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
