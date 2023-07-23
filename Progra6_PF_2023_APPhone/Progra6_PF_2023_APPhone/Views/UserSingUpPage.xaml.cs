using Progra6_PF_2023_APPhone.ViewModels;
using Progra6_PF_2023_APPhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Progra6_PF_2023_APPhone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSingUpPage : ContentPage
    {
        UserWiewModel viewModel;
        public UserSingUpPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserWiewModel();
            LoadUserRolesAsync();
        }

        //funcion que permite la carga de los roles
        private async void LoadUserRolesAsync() 
        {
            PkrUserRole.ItemsSource = await viewModel.GetUserRolesAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            UsuarioRol SelectedUserRole = PkrUserRole.SelectedItem as UsuarioRol;

            bool R = await viewModel.AddUserAsync(TxtBackUpEmail.Text.Trim(),
                                                    TxtPassword.Text.Trim(),
                                                    TxtName.Text.Trim(),
                                                    TxtBackUpEmail.Text.Trim(),
                                                    TxtPhoneNumber.Text.Trim(),
                                                    TxtAddress.Text.Trim(),
                                                    SelectedUserRole.UsuarioRolId);
            if (R)
            {
                await DisplayAlert(":)", "User creted ok!", "ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Something went wrong...", "ok");
            }
        }
    }
}