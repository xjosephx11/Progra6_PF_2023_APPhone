using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progra6_PF_2023_APPhone.Models
{
    public class UsuarioRol
    {
        public RestRequest Request { get; set; }
        public int UsuarioRolId { get; set; }
        public string Descripcion { get; set; } = null!;

        //funciones
        public async Task<List<UsuarioRol>> GetAllUserRoleAsync()
        {
            try
            {
                string RouteSufix = string.Format("UserRoles");
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApikeyName, Services.APIConnection.ApikeyValue);
                RestResponse respnse = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = respnse.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UsuarioRol>>(respnse.Content);    
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
