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
    public class WebApiUsuario
    {

        public static async Task<List<Usuario>> GetUsuarios()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(($"{Constantes.urlBase}/Usuarios/")))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        var content = await response.Content.ReadAsStreamAsync();

                        var serializer = new JsonSerializer();

                        using (var sw = new StreamReader(content))
                        using (var reader = new JsonTextReader(sw))
                        {
                            return serializer.Deserialize<List<Usuario>>(reader);
                        }
                    }
                    else
                    {
                        throw new Exception("No fue posible traer el usuario: " + response.StatusCode);
                    }
                }
            }
        }

        public static async Task<Usuario> GetUsuario(int id)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(($"{Constantes.urlBase}/Usuarios/{id}")))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        var content = await response.Content.ReadAsStreamAsync();

                        var serializer = new JsonSerializer();

                        using (var sw = new StreamReader(content))
                        using (var reader = new JsonTextReader(sw))
                        {
                            return serializer.Deserialize<Usuario>(reader);
                        }
                    }
                    else
                    {
                        throw new Exception("No fue posible traer el usuario: " + response.StatusCode);
                    }
                }
            }
        }
    }
}
