using Newtonsoft.Json;
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
        public List<CartItem> Products { get; set; }
        private decimal totalPrice = 0;
        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set { TotalPrice = value;
                OnPropertyChanged();
            }
        }
        private int _Quantity = 0;
        public int Quantity
        {
            get => _Quantity;
            set
            {
                _Quantity = value;
                OnPropertyChanged();
            }
        }
        public CartViewModel()
        {
            Products = new List<CartItem>();
        }
        public CartViewModel(INavigation navigation, string products)
        {
            Navigation = navigation;
            Products = JsonConvert.DeserializeObject<List<CartItem>>(products);
            TotalPrice = Products.Select(x => (x.Price * x.Quantity)).Sum();
        }

        private void DecreaseQuantity()
        {
            if (Quantity >= 2)
            {
                Quantity--;
            }
        }

        private void IncreaseQuantity()
        {
            Quantity++;
        }
    }



}
