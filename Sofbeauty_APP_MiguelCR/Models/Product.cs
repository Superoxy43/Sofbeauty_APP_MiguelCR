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
    public class Product
    {

        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int ProductsId { get; set; }
        public string ProductsName { get; set; } = null!;

        public int ProductoId { get; set; }

        public string PNombre { get; set; } = null;

        public string Descripcion { get; set; } = null;

        public string Tipo { get; set; } = null;

        public decimal Precio { get; set; }

        public string Imagen { get; set; } 

        public int Existencias { get; set; }

        //funión para cargar productos
        public async Task<List<Product>?> GetProductsAsync()
        {
            try
            {
                //este es el sufijo que completa la ruta de consumo del API
                string RouteSurfix = string.Format("Products");

                string URL = Services.WebAPIConnection.BaseURL + RouteSurfix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get); //donde se pone el verbo correspondiente 

                //agregamos la info de seguridad api key

                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                //se ejecuta la llamada

                RestResponse response = await client.ExecuteAsync(Request);

                //validamos el resultado del llamado del API
                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.OK)
                {
                    //usamos newtonsof para desomponer el json de respuesta del api y convertirlo 
                    //en un objeto de tipo UserRol que se pueda entender en la progra

                    var list = JsonConvert.DeserializeObject<List<Product>>(response.Content);

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



        //función que permite agregar un Productos
        public async Task<bool> AddProductAsync()
        {
            try
            {
                //este es el sufijo que completa la ruta de consumo del API
                string RouteSurfix = string.Format("Products/AddProductFromApp");

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
