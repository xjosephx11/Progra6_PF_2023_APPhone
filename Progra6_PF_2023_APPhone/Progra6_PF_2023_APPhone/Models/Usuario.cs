using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Progra6_PF_2023_APPhone.Models
{
    public class Usuario
    {
        public RestRequest Request { get; set; }

        public int UsuarioId { get; set; }
        public string Email { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string BackupEmail { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public bool? Avtivo { get; set; }
        public string? Addres { get; set; }
        public int UsuarioRolId { get; set; }
        public bool IsBlocked { get; set; }

        public virtual UsuarioRol UsuarioRol { get; set; }
        public Usuario() 
        {
            Avtivo = true;
            IsBlocked = false;
        }

        public async Task<bool> ValidateUserLogin() 
        {
            try
            {
                string RouteSufix = string.Format("Users/ValidateLogin?username={0}&password={1}"
                    ,this.Email, this.Contrasenia);
                //Users/ValidateLogin?username=prueba%40gmail.com&password=1234'
                //Users/ValidateLogin?username=prueba%40gmail.com&password=1234
                string URL = Services.APIConnection.ProductionPrefixURL+RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApikeyName, Services.APIConnection.ApikeyValue);
                RestResponse respnse = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = respnse.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task<bool> AddUserAsync()
        {
            try
            {
                string RouteSufix = string.Format("Usuario"
                    , this.Email, this.Contrasenia);
                //Users/ValidateLogin?username=prueba%40gmail.com&password=1234'
                //Users/ValidateLogin?username=prueba%40gmail.com&password=1234
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Post);
                Request.AddHeader(Services.APIConnection.ApikeyName, Services.APIConnection.ApikeyValue);
                string SeriallizedModelObject = JsonConvert.SerializeObject(this);
                Request.AddBody(SeriallizedModelObject, GlobalObjects.MimeType);
                RestResponse respnse = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = respnse.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
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
