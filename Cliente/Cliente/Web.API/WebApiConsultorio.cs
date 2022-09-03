using Cliente.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Web.API
{
    public class WebApiConsultorio
    {
        public static async Task<Consultorio> GetConsultorio(int idUsuario)
        {
            using (var client = new HttpClient())
            {

                using (var response = await client.GetAsync(($"{Constantes.urlBase}/Consultorios/{idUsuario}")))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStreamAsync();
                        var serializer = new JsonSerializer();

                        using (var sw = new StreamReader(content))
                        using (var reader = new JsonTextReader(sw))
                        {
                            return serializer.Deserialize< Consultorio > (reader);
                        }
                    }
                    else
                    {
                        throw new Exception("No fue posible traer las citas: " + response.StatusCode);
                    }
                }
            }
        }



    }
}
