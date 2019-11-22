using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAnimations.Services;
using XamarinAnimations.Views;

namespace XamarinAnimations
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
           // MainPage = new AppShell();
            MainPage = new Views.Page1.View1();
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
