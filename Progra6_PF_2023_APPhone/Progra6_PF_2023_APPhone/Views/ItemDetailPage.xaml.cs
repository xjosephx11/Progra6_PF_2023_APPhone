using Progra6_PF_2023_APPhone.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Progra6_PF_2023_APPhone.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}