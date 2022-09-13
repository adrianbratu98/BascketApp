using System;
namespace BascketApp.Application.Models
{
    public class BascketDTO
    {
        public int Id { get; set; }

        public decimal TotalNet { get; set; }

        public decimal TotalGross { get; set; }

        public List<BascketArticleDTO>? Articles { get; set; }

        public BascketDTO()
        {
        }
    }
}

