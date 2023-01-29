﻿using PizzeriaApp.Services;
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
        public Command LoadProductsCommand { get;}
        public Command ProductTapEdit { get;}
        public Command ProductTapDelete { get;}

        public ICommand NavigateToBasketCommand { get; }
        public Command AddProductToBasket { get; }
        public INavigation Navigation { get; set; }
        public List<Product> ProductList { get; }
        private int _counter = 0;
        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Product> Products { get; set;}
        public ProductViewModel(INavigation navigation)
        {
            ProductList = new List<Product>();
            LoadProductsCommand = new Command(async() => await ExecuteLoadProductsCommand());
            Products = new ObservableCollection<Product>();
            ProductTapEdit = new Command<Product>(OnEditProduct);
            ProductTapDelete = new Command<Product>(OnDeleteProduct);
            Navigation = navigation;
            NavigateToBasketCommand = new Command(async()=> await Navigation.PushAsync(new CartPage()));
            AddProductToBasket = new Command<Product>(OnAddProductToBasket);
        }

        private void OnAddProductToBasket(Product product)
        {
            if (product == null)
            {
                return;
            }
            
            App.Products.Add(product);
            AddToBasketCounter();
        }

        public void AddToBasketCounter()
        {
            Counter = Counter + 1;
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
            await App.DataBase.DeleteProductAsync(product.Id);
            await ExecuteLoadProductsCommand();
        }

        private async Task ExecuteLoadProductsCommand()
        {

            IsBusy = true;
            try
            {
                Products.Clear();
                var products = await App.DataBase.GetProductsAsync();
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
