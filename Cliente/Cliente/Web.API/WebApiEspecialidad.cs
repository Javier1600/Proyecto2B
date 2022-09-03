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
    public class WebApiEspecialidad
    {
        public static async Task<List<Especialidad>> GetEspecialidades()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(($"http://localhost/AgendamientoService/Especialidad/")))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        var content = await response.Content.ReadAsStreamAsync();

                        var serializer = new JsonSerializer();

                        using (var sw = new StreamReader(content))
                        using (var reader = new JsonTextReader(sw))
                        {
                            return serializer.Deserialize<List<Especialidad>>(reader);
                        }
                    }
                    else
                    {
                        throw new Exception("No fue posible traer la especialidad: " + response.StatusCode);
                    }
                }
            }
        }

    }
}
