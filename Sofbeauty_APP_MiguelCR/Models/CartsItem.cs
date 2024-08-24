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
    public class CartsItem
    {

        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int CarritoObjID { get; set; }

        public int CarritoId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        //función que permite agregar un usuario
        public async Task<bool> AddCartsItemAsync()
        {
            try
            {
                //este es el sufijo que completa la ruta de consumo del API
                string RouteSurfix = string.Format("CartsItems/AddCartsItemFromApp");

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
