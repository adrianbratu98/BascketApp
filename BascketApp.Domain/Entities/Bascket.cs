using System;
namespace BascketApp.Domain.Entities
{
    public class Bascket
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public bool PaysVAT { get; set; }

        public virtual ICollection<BascketArticle>? Articles { get; set; }

        public bool Close { get; set; }

        public bool Payed { get; set; }

        public Bascket(string customer, bool paysVAT)
        {
            Customer = customer;
            PaysVAT = paysVAT;
        }
    }
}

