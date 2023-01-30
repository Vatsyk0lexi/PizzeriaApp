using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace PizzeriaApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public List<Product> Products { get; set; }
        public MainViewModel()
        {
            Products =  GetPopularProducts();
            GetProductsCommand = new Command(() =>
            {
                var tab = new TabbedPage1();
                tab.CurrentPage = tab.Children[1];
                Application.Current.MainPage.Navigation.PushAsync(tab);
            });
        }

        private  List<Product> GetPopularProducts()
        {
            return new List<Product>()
            {
<<<<<<< HEAD
                new Product(){ImageUrl="pepperoni", Description="Lorem ipsun",Name="Пепероні" },
=======
                new Product(){ImageUrl="https://goodsushi.if.ua/image/cache/webp/catalog/photo/%D0%9F%D1%96%D1%86%D0%B0/%D0%A1%D0%B0%D0%BB%D1%8F%D0%BC%D1%96%D0%BD%D0%BE_Site-700x700.webp", Description="desc",Name="Саляміно" },
>>>>>>> 9b0d7ac0fde05132254ad8940dedee9afd1a46a6
                 new Product(){ImageUrl="https://goodsushi.if.ua/image/cache/webp/catalog/photo/%D0%9F%D1%96%D1%86%D0%B0/%D0%A1%D0%B0%D0%BB%D1%8F%D0%BC%D1%96%D0%BD%D0%BE_Site-700x700.webp", Description="Опис",Name="Салямі" },
            };
        }

        public ICommand GetProductsCommand { get; }
    }


    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

}
