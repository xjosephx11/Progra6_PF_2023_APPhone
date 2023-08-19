using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Progra6_PF_2023_APPhone.ViewModels;

namespace Progra6_PF_2023_APPhone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosListPage : ContentPage
    {
        ProductoViewModel productoViewModel;
        public ProductosListPage()
        {
            InitializeComponent();
            BindingContext = productoViewModel = new ProductoViewModel();
            LoadProductoList();
        }

        private async void LoadProductoList()
        {
            LvList.ItemsSource = await productoViewModel.GetProductosAsync(GlobalObjects.MyLocalUser.IDUsuariodto);
        }
    }
}