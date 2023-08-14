using Progra6_PF_2023_APPhone.Models;
using Progra6_PF_2023_APPhone.ViewModels;
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
    public partial class UserManagementPage : ContentPage
    {
        UserWiewModel viewModel;
        public UserManagementPage()
        {
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            TxtID.Text = GlobalObjects.MyLocalUser.IDUsuariodto.ToString();
            TxtEmail.Text = GlobalObjects.MyLocalUser.Correodto;
            TxtName.Text = GlobalObjects.MyLocalUser.Nombredto;
            TxtPhoneNumber.Text = GlobalObjects.MyLocalUser.Telefonodto;
            TxtBackUpEmail.Text = GlobalObjects.MyLocalUser.correoRespaldodto;
            TxtAddress.Text = GlobalObjects.MyLocalUser.direcciondto;
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                UserDTO BackUpLocalUser = new UserDTO();
                BackUpLocalUser = GlobalObjects.MyLocalUser;

                try
                {
                    GlobalObjects.MyLocalUser.Nombredto = TxtName.Text.Trim();
                    GlobalObjects.MyLocalUser.correoRespaldodto = TxtBackUpEmail.Text.Trim();
                    GlobalObjects.MyLocalUser.Telefonodto = TxtPhoneNumber.Text.Trim();
                    GlobalObjects.MyLocalUser.direcciondto = TxtAddress.Text.Trim();

                    var answer = await DisplayAlert("???", "Esta seguro de continuar con la actualizacion del usuario?", "Yes", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdateUser(GlobalObjects.MyLocalUser);
                        if (R)
                        {
                            await DisplayAlert(":)", "Usuario Actualizado!", "ok");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert(":(", "Algo salio mal...", "ok");
                            await Navigation.PopAsync();
                        }
                    }
                }
                catch (Exception)
                {
                    //si  algosale mal reversamos los cambios
                    GlobalObjects.MyLocalUser = BackUpLocalUser;
                    throw;
                }
                finally
                {

                }
            }
        }

        private bool ValidateFields()
        {
            bool R = false;
            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtBackUpEmail.Text != null && !string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()) &&
                TxtPhoneNumber.Text != null && !string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
            {
                
                R = true;
            }
            else
            {
                //si falta algun dato obligatorio
                if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()))
                {
                    DisplayAlert("Validacion Fallida", "El nombre es requerido", "ok");
                    TxtName.Focus();
                    return false;
                }
                if (TxtBackUpEmail.Text == null || string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()))
                {
                    DisplayAlert("Validacion Fallida", "El BackUp-Email es requerido", "ok");
                    TxtBackUpEmail.Focus();
                    return false;
                }
                if (TxtPhoneNumber.Text == null || string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
                {
                    DisplayAlert("Validacion Fallida", "El numero telefonico es requerido", "ok");
                    TxtPhoneNumber.Focus();
                    return false;
                }

            }

            return R;
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}