using System;
namespace BascketApp.Application.Models
{
    public class PutBascketArticleDTO
    {
        public string Item { get; set; }

        public decimal Price { get; set; }

        public PutBascketArticleDTO(string item)
        {
            Item = item;
        }
    }
}

