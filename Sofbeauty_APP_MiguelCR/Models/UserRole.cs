using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Sofbeauty_APP_MiguelCR.Models
{
    public class UserRole
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }

        //atributos de la clase, en este ejemplo usaremos la clase nativa
        //luego lo cambiaremos por el DTO 

        public int UserRoleId { get; set; }

        public string UserRoleDescription { get; set; } = null!;

        //crear la función que consume el get que entrega todos los roles
        //desde el API 

        public async Task<List<UserRole>?> GetUserRolesAsync()
        {
            try
            {
                //este es el sufijo que completa la ruta de consumo del API
                string RouteSurfix = string.Format("UserRoles");

                string URL = Services.WebAPIConnection.BaseURL + RouteSurfix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get); //donde se pone el verbo correspondiente 

                //agregamos la info de seguridad api key

                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                //se ejecuta la llamada

                RestResponse response = await client.ExecuteAsync(Request);

                //validamos el resultado del llamado del API
                HttpStatusCode statusCode = response.StatusCode;

                if (response!= null && statusCode == HttpStatusCode.OK)
                {
                    //usamos newtonsof para desomponer el json de respuesta del api y convertirlo 
                    //en un objeto de tipo UserRol que se pueda entender en la progra

                    var list = JsonConvert.DeserializeObject<List<UserRole>>(response.Content);

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
