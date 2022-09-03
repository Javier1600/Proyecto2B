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
    public class WebApiLogin
    {
        public static async Task<Usuario> PostValidarClave(LoginRequest login)
        {
            

            var json = JsonConvert.SerializeObject(login);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync($"{Constantes.urlBase}/Login/ValidarClave", data))
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
                        throw new Exception("Datos Erroneos" );
                    }
                }
            }
        }

    }
}
