using Consumir_API_GML.Models;
//calses para agregar lo de http client
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace Consumir_API_GML.Servicios
{
    public class NProducto
    {
        private static readonly HttpClient client = new HttpClient();
        const string urlWebAPI = "http://localhost:5051/api/Productoes";

        public NProducto()
        {
        }
        //===========================================CONSULTAR TODOS=====================================================================
        public List<Producto> Consultar()
        {
            var producto = new List<Producto>();
            try
            {
                //Instancia el objeto HttpClient
                using (var client = new HttpClient())
                {
                    //Invoca el método GetAsync del objeto HttpClient, el cual envía una solicitud GET al
                    //URI especificado como parámetro, como una operación asincrónica
                    Task<HttpResponseMessage> responseTask = client.GetAsync("http://localhost:5051/api/Productoes");

                    // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                    responseTask.Wait();

                    //Obtenemos el objeto HttpResponseMessage a través de la propiedad Result del objeto Task<HttpResponseMessage>
                    HttpResponseMessage result = responseTask.Result;

                    // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                    // desde la web api, en caso contrario enviamos una excepción
                    if (result.IsSuccessStatusCode)
                    {
                        //Invocamos al método ReadAsStringAsync del objeto HttpContent el cual serializa
                        //el contenido HTTP en una cadena como una operación asincrónica. 
                        Task<string> readTask = result.Content.ReadAsStringAsync();

                        // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                        readTask.Wait();

                        //Obtenemos el string en formato json del objeto recibido
                        string json = readTask.Result;

                        //Deserealizamos el objeto recibido, en este caso una lista de estados
                        producto = JsonConvert.DeserializeObject<List<Producto>>(json);
                    }
                    else //web api envió error de respuesta
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }
            return producto;
        }

        //===========================================AGREGAR=====================================================================
        public void Agregar(Producto producto)
        {
            using (var client = new HttpClient())
            {

                //Creamos un objeto HttpContent instanciando un objeto StringContent, la cual es una clase derivada de HttpContent.
                //Este contenido se crea con el objeto Estado que se está recibiendo
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8);

                //Asignamos a la propiedad ContentType del encabezado de HttpContent
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //Invoca el método PostAsync del objeto HttpClient, el cual envía una solicitud POST al
                //URI especificado como parámetro, como una operación asincrónica, asimismo le envía el contenido (objeto estado) dentro del httpContect
                var postTask = client.PostAsync(urlWebAPI, httpContent);

                // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                postTask.Wait();

                //Obtenemos el objeto HttpResponseMessage a través de la propiedad Result del objeto Task<HttpResponseMessage>
                var result = postTask.Result;

                // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                // desde la web api, en caso contrario enviamos una excepción
                if (result.IsSuccessStatusCode)
                {
                    // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                    // desde la web api, en caso contrario enviamos una excepción
                    var readTask = result.Content.ReadAsStringAsync();
                    // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                    readTask.Wait();
                    //Obtenemos el string en formato json del objeto recibido
                    string json = readTask.Result;
                    //Deserealizamos el objeto recibido, en este caso un estado
                    producto = JsonConvert.DeserializeObject<Producto>(json);
                }
                else //web api envió error de respuesta
                {
                    throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                }
            }
        }
    }
}
