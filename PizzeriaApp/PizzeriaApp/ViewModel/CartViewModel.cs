using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PizzeriaApp.ViewModel
{
    class CartViewModel : BaseProductViewModel
    {
        public INavigation Navigation { get; set; }
        public List<Product> Products { get; set; }
        public CartViewModel()
        {
            Products = App.Products;
            TotalPrice = Products.Select(x => x.Price).Sum();
        }
        public CartViewModel(INavigation navigation, List<Product> products)
        {
            Navigation= navigation;
            Products = products;
            TotalPrice = Products.Select(x => x.Price).Sum();
        }
        
        private decimal totalPrice=0;
        public decimal TotalPrice { 
            get
            {
                return totalPrice;
            } 
            set { TotalPrice = totalPrice;  } }
    }
}
