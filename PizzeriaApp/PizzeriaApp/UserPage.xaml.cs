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
    public partial class UserPage : ContentPage
    {
        private ApiService _ApiService = new ApiService();
        public UserPage()
        {
            InitializeComponent();
            UserName.Text = App.CurrentUser?.Username;
            Password.Text = App.CurrentUser?.Username;
            Email.Text = App.CurrentUser?.Email;
            NumberPhone.Text = App.CurrentUser?.NumberPhone;
            SaveButton.Clicked += SaveButton_Clicked;
            LogOut.Clicked += LogOut_Clicked;
        }

        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            Application.Current.Properties["IsLoggedIn"] = Boolean.FalseString;
            App.Token = string.Empty;
            App.CurrentUser =null;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var user = new RegisterViewModel()
            {
                Username = UserName.Text,
                Password = Password.Text,
                Email = Email.Text,
                NumberPhone = NumberPhone.Text
            };
            var isSuccess = await _ApiService.UpdateAsync(user);
            if (isSuccess)
            {
                await DisplayAlert("Повідомлення!", "Успішно збережно!", "Ok");

            }
            else
            {
                await DisplayAlert("Повідомлення!", "Виникла помилка при  збереженні", "Ok");

            }
        }

         
    }
}