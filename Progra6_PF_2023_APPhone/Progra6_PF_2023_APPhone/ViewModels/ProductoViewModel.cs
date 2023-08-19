using Progra6_PF_2023_APPhone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Progra6_PF_2023_APPhone.ViewModels
{
    public class ProductoViewModel : BaseViewModel
    {
        public Producto MyProducto { get; set; }
        public ProductoViewModel()
        {
            MyProducto = new Producto();    
                
        }

        public async Task<ObservableCollection<Producto>> GetProductosAsync(int pUserID) 
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Producto> productos = new ObservableCollection<Producto>();
                MyProducto.UsuarioId = pUserID;
                productos = await MyProducto.GetProductoListByUserAsync();
                if (productos != null)
                {
                    return null;
                }
                return productos;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }



    }
}
