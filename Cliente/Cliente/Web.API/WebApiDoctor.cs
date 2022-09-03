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
    public class WebApiDoctor
    {
        public static async Task<List<Doctor>> GetDoctores()
        {
            using (var client = new HttpClient())
            {

                using (var response = await client.GetAsync(($"{Constantes.urlBase}/Doctores/")))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStreamAsync();
                        var serializer = new JsonSerializer();

                        using (var sw = new StreamReader(content))
                        using (var reader = new JsonTextReader(sw))
                        {
                            return serializer.Deserialize<List<Doctor>>(reader);
                        }
                    }
                    else
                    {
                        throw new Exception("No fue posible Doctores: " + response.StatusCode);
                    }
                }
            }
        }

        public static async Task<Doctor> GetDoctor(int idDoctor)
        {
            using (var client = new HttpClient())
            {

                using (var response = await client.GetAsync(($"{Constantes.urlBase}/Doctores/{idDoctor}")))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStreamAsync();
                        var serializer = new JsonSerializer();

                        using (var sw = new StreamReader(content))
                        using (var reader = new JsonTextReader(sw))
                        {
                            return serializer.Deserialize<Doctor>(reader);
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
