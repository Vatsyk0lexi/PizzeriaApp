using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace PizzeriaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public  LoginPage()
        {
            InitializeComponent();
        }


        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void GoToRegisterPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

    }
}