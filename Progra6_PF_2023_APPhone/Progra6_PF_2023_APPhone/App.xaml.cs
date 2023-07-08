using Progra6_PF_2023_APPhone.Services;
using Progra6_PF_2023_APPhone.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Progra6_PF_2023_APPhone
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new AppLoginPage());
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
