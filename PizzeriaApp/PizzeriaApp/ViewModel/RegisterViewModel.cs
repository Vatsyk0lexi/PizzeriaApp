﻿using PizzeriaApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PizzeriaApp.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private ApiService _ApiService = new ApiService();
        private INavigation navigation;

        public RegisterViewModel()
        {

        }
        public RegisterViewModel(INavigation Navigation)
        {
            navigation= Navigation;
        }

        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NumberPhone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public ICommand Register
        {
            get
            {
                return new Command(async () =>
                {
                    bool isSuccess = await _ApiService.RegisterAsync(Email, Password, Username, NumberPhone);
                    if (isSuccess)
                    {
                        Message = "Ви успішно зареєструвались";
                        await navigation.PushAsync(new LoginPage(Message),true);
                    }
                    else
                    {
                        Message = "Виникла помилка при  реєстрації";
                        await navigation.PushAsync(new RegisterPage(Message), true);
                    }
                });
            }
        }
        public ICommand Login
        {
            get
            {
                return new Command(async () =>
                {
                    bool isSuccess = await _ApiService.LoginAsync(Email, Password);
                    if (isSuccess)
                    {
                        await navigation.PushAsync(new TabbedPage1(), true);
                    }
                    else
                    {
                        Message = "Виникла помилка при  авторизації";
                        await navigation.PushAsync(new LoginPage(Message), true);
                    }
                });
            }
        }

    }
}
