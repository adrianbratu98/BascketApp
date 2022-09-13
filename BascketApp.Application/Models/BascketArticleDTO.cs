using System;
namespace BascketApp.Application.Models
{
    public class BascketArticleDTO
    {
        public string Item { get; set; }

        public decimal Price { get; set; }

        public BascketArticleDTO(string item)
        {
            Item = item;
        }
    }
}

