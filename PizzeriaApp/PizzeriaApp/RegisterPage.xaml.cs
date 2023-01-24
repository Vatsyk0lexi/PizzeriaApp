using PizzeriaApp.Services;
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
    public partial class RegisterPage : ContentPage
    {
        
        public RegisterPage(string message = "")
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(Navigation);
            if (message.Length > 0)
            {
                DisplayAlert("Повідомлення!", $"{message}", "Ok");
            }

        }
        private async void GoToLoginPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

    }
}