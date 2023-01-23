using PizzeriaApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzeriaApp
{
    public partial class App : Application
    {
        public static User CurrentUser { get; set; } = null;
        public App()
        {

            InitializeComponent();
            Device.SetFlags(new[] { "Shapes_Experimental", "Brush_Experimental" });

            if (CurrentUser == null)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
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
