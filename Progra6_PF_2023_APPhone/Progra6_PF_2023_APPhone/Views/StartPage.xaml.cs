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
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();
			LoadUserName();
		}

		private void LoadUserName() 
		{
			LblUserName.Text = GlobalObjects.MyLocalUser.Nombredto.ToUpper();
		}

        private async void BtnUserManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserManagementPage());
        }

        private async void BtnProducto_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new ProductosListPage());
        }
    }
}