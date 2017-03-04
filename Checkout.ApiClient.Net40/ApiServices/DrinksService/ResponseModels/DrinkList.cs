using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkout.ApiServices.DrinksService.ResponseModels
{
    public class DrinkList
    {
        public List<Drink> Data { get; set; }
        public int Count { get; set; }
    }
}
