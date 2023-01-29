﻿using Newtonsoft.Json;
using PizzeriaApp.Services;
using PizzeriaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzeriaApp
{
    public partial class App : Application
    {
        public static List<Product> Products { get; set; } = new List<Product>();
        private static DataBase _dataBase;
        public static DataBase DataBase
        {
            get
            {
                if (_dataBase == null)
                {
                    _dataBase = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3"));
                }
                return _dataBase;
            }
        }
        public static User CurrentUser { get; set; }

        public static string Token { get; set; } = string.Empty;
        public App()
        {

            InitializeComponent();
            Device.SetFlags(new[] { "Shapes_Experimental", "Brush_Experimental" });
            bool isLoggedIn = Current.Properties.ContainsKey("IsLoggedIn") ? Convert.ToBoolean(Current.Properties["IsLoggedIn"]) : false;
            if (!isLoggedIn)
            {

                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                Token = App.Current.Properties["Token"].ToString();
                CurrentUser = JsonConvert.DeserializeObject<User>((string)App.Current.Properties["UserDetails"]);
                MainPage = new NavigationPage(new TabbedPage1());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
