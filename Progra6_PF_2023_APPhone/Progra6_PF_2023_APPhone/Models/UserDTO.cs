using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progra6_PF_2023_APPhone.Models
{
    public class UserDTO
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }
        public int IDUsuariodto { get; set; }
        public string Correodto { get; set; } = null!;
        public string Contraseniadto { get; set; } = null!;
        public string Nombredto { get; set; } = null!;
        public string correoRespaldodto { get; set; } = null!;
        public string Telefonodto { get; set; } = null!;
        public bool? Avtivodto { get; set; }
        public string? direcciondto { get; set; }
        public int idroldto { get; set; }
        public bool estaBloqueadodto { get; set; }
        public string descripcionRoldto { get; set; } = null!;

        public async Task<UserDTO> GetUserInfo(string pEmail)
        {
            try
            {
                string RouteSufix = string.Format("Users/GetUserInfoByEmail?email={0}", pEmail);
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApikeyName, Services.APIConnection.ApikeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                RestResponse respnse = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = respnse.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(respnse.Content);
                    var item = list[0];
                    return item;
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

        public async Task<bool> UpdateUserAsync()
        {
            try
            {

                string RouteSufix = string.Format("Users/{0}", this.IDUsuariodto);
                //armamos la ruta completa al endpoint en el api
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Put);
                //agregamos mecanismo de seguridad, en este caso apikey
                Request.AddHeader(Services.APIConnection.ApikeyName, Services.APIConnection.ApikeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                //en  el caso de una operacion post debemos serializar
                //el objeto para pasarlo como json al api
                string SerializedModelObject = JsonConvert.SerializeObject(this);
                //agregamos el objeto serializado en el cuerpo del request
                Request.AddBody(SerializedModelObject, GlobalObjects.MimeType);

                //ejecutar la llamada al api
                RestResponse response = await client.ExecuteAsync(Request);
                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;
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








    }
}
