﻿namespace Cozma_Laurentiu_Lab2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId {  get; set; }
        public Customer Customer { get; set; }
        public Book Book { get; set; }
    }
}
