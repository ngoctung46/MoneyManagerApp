using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace MoneyManagerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var bootStrapper = new AppBootstrapper();
            MainPage = bootStrapper.CreateMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}