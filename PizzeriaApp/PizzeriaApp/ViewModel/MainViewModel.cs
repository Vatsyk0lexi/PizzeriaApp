using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace PizzeriaApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Picks = GetPicks();
            GetProductsCommand = new Command(() =>
            {
                var tab = new TabbedPage1();
                tab.CurrentPage = tab.Children[1];
                Application.Current.MainPage.Navigation.PushAsync(tab);
            });
        }

        public List<Pick> Picks { get; set; }

        public ICommand GetProductsCommand { get; }

        private List<Pick> GetPicks()
        {
            return new List<Pick>
            {
                new Pick { Title = "Breakfast", Image = "IMG01.png",
                    Description = "Order our healthy and warm breakfast menu for a great morning" },
                new Pick { Title = "Lunch", Image = "IMG03.png",
                    Description = "Delicious lunch to keep your day sweet and smooth" }
            };
        }
    }

    public class Pick
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
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
