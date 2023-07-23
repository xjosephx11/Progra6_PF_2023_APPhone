using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Progra6_PF_2023_APPhone.ViewModels;
using Acr.UserDialogs;

namespace Progra6_PF_2023_APPhone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {
        UserWiewModel viewModel;

        public AppLoginPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new UserWiewModel();
        }

        private void SwShowPassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwShowPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (TxtUserName.Text != null && !string.IsNullOrEmpty(TxtUserName.Text.Trim()) &&
                TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Checking User Access....");
                    await Task.Delay(2000);
                    string username = TxtUserName.Text.Trim();
                    string password = TxtPassword.Text.Trim();

                    bool R = await viewModel.UserAccessValidation(username, password);
                    if (R)
                    {
                        //todo: crear el objeto de usuario global.
                        await Navigation.PushAsync(new StartPage());
                        return;
                    }
                    else
                    {
                        await DisplayAlert("User Access Denied", "Username or Password are incorrect", "ok");
                        return;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally 
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
            else 
            {
                await DisplayAlert("Data required","Username or Password are required...","ok");
                return;
            }
        }

        private async void BtnSingUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserSingUpPage());
        }
    }
}