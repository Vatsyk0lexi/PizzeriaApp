using PizzeriaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace PizzeriaApp.ViewModel
{
    public class ProductViewModel : BaseProductViewModel
    {
        private readonly DataBase dataBase;
        
        public Command LoadProductsCommand { get;}
        public Command ProductTapEdit { get;}
        public Command ProductTapDelete { get;}
        public ObservableCollection<Product> Products { get; set;}
        public ProductViewModel(INavigation navigation)
        {
            dataBase = App.DataBase;
            LoadProductsCommand = new Command(async() => await ExecuteLoadProductsCommand());
            Products = new ObservableCollection<Product>();
            ProductTapEdit = new Command<Product>(OnEditProduct);
            ProductTapDelete = new Command<Product>(OnDeleteProduct);
            Navigation = navigation;

        }

        private async void OnEditProduct(Product product)
        {
            await Navigation.PushAsync(new AddProductPage(product));
        }
        private async void OnDeleteProduct(Product product)
        {
            if (product==null)
            {
                return;
            }
            await dataBase.DeleteProductAsync(product.Id);
            await ExecuteLoadProductsCommand();
        }
        
        private async Task ExecuteLoadProductsCommand()
        {

            IsBusy = true;
            try
            {
                Products.Clear();
                var products = await dataBase.GetProductsAsync();
                foreach (var item in products)
                {
                    Products.Add(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
            

        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
