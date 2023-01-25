﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzeriaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1(string message = "")
        {
            InitializeComponent();
            if (message.Length > 0)
            {
                DisplayAlert("Повідомлення!", $"{message}", "Ok");
            }
        }
    }
}