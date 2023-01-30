using PizzeriaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzeriaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        
        ProductViewModel productViewModel;

        public ProductPage()
        {
            InitializeComponent();
            BindingContext = productViewModel = new ProductViewModel(Navigation);
<<<<<<< HEAD
            ImageMainButton.Clicked += ImageMainButton_Clicked;
        }
      

        
=======

            ImageMainButton.Clicked += ImageMainButton_Clicked;
        }

>>>>>>> 9b0d7ac0fde05132254ad8940dedee9afd1a46a6
        private async void ImageMainButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedPage1());
        }

        private async void AddProductButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage());
        }
<<<<<<< HEAD
        private async void GoToBasketPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }
=======

>>>>>>> 9b0d7ac0fde05132254ad8940dedee9afd1a46a6
        protected override void OnAppearing()
        {
            base.OnAppearing();
            productViewModel.OnAppearing();
          
        }

        private void CarouselPositionChanged(object sender, PositionChangedEventArgs e)
        {

            var carousel = sender as CarouselView;
            var views = carousel.VisibleViews;

            if (views.Count > 0)
            {
                foreach (var view in views)
                {
                    var img = view.FindByName<Image>("MenuImg");
                    ViewExtensions.CancelAnimations(img);

                    Task.Run(async () => await img.RelRotateTo(360, 5000, Easing.BounceOut));
                }
            }
        }
    }
}