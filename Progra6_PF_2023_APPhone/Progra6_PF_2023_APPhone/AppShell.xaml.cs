using Progra6_PF_2023_APPhone.ViewModels;
using Progra6_PF_2023_APPhone.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Progra6_PF_2023_APPhone
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
