using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sofbeauty_APP_MiguelCR.Models
{
    public class User
    {
        //acá no hace falta nombrar el objeto como DTO, solo es necesario en el API
        //De hecho el equipo de desarrollo no debería saber la forma del modelo nativo
        //en el API.

        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int UsuarioID { get; set; }
        public string Correo { get; set; } = null;
        public string Nombre { get; set; } = null;
        public string Telefono { get; set; }
        public string contrasennia { get; set; } = null;
        public int RolId { get; set; }
        public string? RolDescripcion { get; set; }

        //función que permite agregar un usuario
        public async Task<bool> AddUserAsync()
        {
            try
            {
                //este es el sufijo que completa la ruta de consumo del API
                string RouteSurfix = string.Format("Users/AddUserFromApp");

                string URL = Services.WebAPIConnection.BaseURL + RouteSurfix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post); //donde se pone el verbo correspondiente 

                //agregamos la info de seguridad api key

                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                //cuando enviamos objetos hacia el API debemos serializarlos antes 

                string SerializedModel = JsonConvert.SerializeObject(this);

                Request.AddBody(SerializedModel);



                //se ejecuta la llamada

                RestResponse response = await client.ExecuteAsync(Request);

                //validamos el resultado del llamado del API
                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.Created)
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
