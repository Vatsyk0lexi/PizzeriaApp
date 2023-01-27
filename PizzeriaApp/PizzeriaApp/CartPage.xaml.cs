using PizzeriaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzeriaApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartPage : ContentPage
	{
        CartViewModel cartViewModel;
        public CartPage()
        {
            InitializeComponent();
            BindingContext = cartViewModel = new CartViewModel();
        }
        public CartPage (List<Product> products)
		{
			InitializeComponent ();
            BindingContext = cartViewModel = new CartViewModel(Navigation,products);
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}