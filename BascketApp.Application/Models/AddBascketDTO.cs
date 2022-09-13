using System;
namespace BascketApp.Application.Models
{
    public class AddBascketDTO
    {
        public string Customer { get; set; }

        public bool PaysVAT { get; set; }

        public AddBascketDTO(string customer)
        {
            Customer = customer;
        }
    }
}

