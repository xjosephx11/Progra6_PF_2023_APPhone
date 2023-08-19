using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Progra6_PF_2023_APPhone.Models
{
    public class Producto
    {
        public Producto()
        {
            //ApartadosProductos = new HashSet<ApartadosProducto>();
        }

        [JsonIgnore]
        public RestRequest Request { get; set; }    

        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Stock { get; set; } = null!;
        public string Talla { get; set; } = null!;
        public string Precio { get; set; } = null!;
        public bool? Activo { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaProductoId { get; set; }

        public virtual CategoriaProducto? CategoriaProducto { get; set; } = null!;
        public virtual ICollection<ApartadosProducto>? ApartadosProductos { get; set; }

        //funciones
        public async Task<ObservableCollection<Producto>> GetProductoListByUserAsync()
        {
            try
            {
                string RouteSufix = string.Format("api/Productoes/GetProductoListByUser?id={0}",this.UsuarioId);
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApikeyName, Services.APIConnection.ApikeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                RestResponse respnse = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = respnse.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<ObservableCollection<Producto>>(respnse.Content);
                    
                    return list;
                }
                else
                {
                    return null;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }




    }
}
