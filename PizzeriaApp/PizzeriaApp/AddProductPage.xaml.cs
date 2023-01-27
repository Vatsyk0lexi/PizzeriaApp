using PizzeriaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace PizzeriaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPage : ContentPage
    {
        public AddProductPage(Product product)
        {
            InitializeComponent();
            BindingContext = new AddProductPageViewModel(Navigation);
            if (product !=null)
            {
               ((AddProductPageViewModel)BindingContext).Product = product;

            }
            
        }
        public AddProductPage()
        {
            InitializeComponent();
            BindingContext =  new AddProductPageViewModel(Navigation);
        }


    }
}