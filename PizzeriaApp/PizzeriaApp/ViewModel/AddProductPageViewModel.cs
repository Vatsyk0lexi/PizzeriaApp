using PizzeriaApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PizzeriaApp.ViewModel
{
    public class AddProductPageViewModel : BaseProductViewModel
    {
        public INavigation Navigation { get; }
        public Command SaveComand { get; }
        public Command CancelComand { get; }
        public AddProductPageViewModel(INavigation navigation)
        {
            SaveComand = new Command(OnSave);
            CancelComand = new Command(OnCancel);

            this.PropertyChanged += (_, __) => SaveComand.ChangeCanExecute();

            Product = new Product();
            Navigation = navigation;
        }

        private async void OnSave(object obj)
        {
            var product = Product;
            await App.DataBase.AddProductAsync(product);

            await Navigation.PushAsync(new ProductPage());
        }

        private async void OnCancel(object obj)
        {
            await Navigation.PushAsync(new ProductPage());
        }
    }
}
