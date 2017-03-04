using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Checkout.ApiServices.DrinksService.RequestModels;

namespace Checkout.ApiServices.DrinksService.ResponseModels
{
    public class Drink : BaseDrink
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
