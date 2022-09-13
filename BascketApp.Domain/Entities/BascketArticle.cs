using System;
namespace BascketApp.Domain.Entities
{
    public class BascketArticle
    {
        public int Id { get; set; }

        public int BascketId { get; set; }

        public string Item { get; set; }

        public decimal Price { get; set; }

        public Bascket Bascket { get; set; }  

        public BascketArticle(string item)
        {
            Item = item;
        }
    }
}

