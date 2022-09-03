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
    public class WebApiCita
    {
        public static async Task<List<Cita>> GetCitas(DateTime fecha, int idEspecialidad)
        {
            using (var client = new HttpClient())
            {
                var strFecha = fecha.ToString("yyyy/MM/dd").Split(' ')[0];

                using (var response = await client.GetAsync(($"{Constantes.urlBase}/Citas/{idEspecialidad}/Fecha/?fecha={strFecha}")))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStreamAsync();
                        var serializer = new JsonSerializer();

                        using (var sw = new StreamReader(content))
                        using (var reader = new JsonTextReader(sw))
                        {
                            return serializer.Deserialize<List<Cita>>(reader);
                        }
                    }
                    else
                    {
                        throw new Exception("No fue posible traer las citas: " + response.StatusCode);
                    }
                }
            }
        }

        public static async Task<List<Cita>> GetCitas()
        {
            using (var client = new HttpClient())
            {

                using (var response = await client.GetAsync(($"{Constantes.urlBase}/Citas")))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStreamAsync();
                        var serializer = new JsonSerializer();

                        using (var sw = new StreamReader(content))
                        using (var reader = new JsonTextReader(sw))
                        {
                            return serializer.Deserialize<List<Cita>>(reader);
                        }
                    }
                    else
                    {
                        throw new Exception("No fue posible traer las citas: " + response.StatusCode);
                    }
                }
            }
        }

        public static async Task<List<Cita>> GetCitasAgendadas(int idPaciente)
        {
            using (var client = new HttpClient())
            {

                using (var response = await client.GetAsync(($"{Constantes.urlBase}/Citas/Paciente/{idPaciente}")))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStreamAsync();
                        var serializer = new JsonSerializer();

                        using (var sw = new StreamReader(content))
                        using (var reader = new JsonTextReader(sw))
                        {
                            return serializer.Deserialize<List<Cita>>(reader);
                        }
                    }
                    else
                    {
                        throw new Exception("No fue posible traer las citas: " + response.StatusCode);
                    }
                }
            }
        }

        public static async Task<bool> AgendarCita(Cita cita)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(cita);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (var response = await client.PutAsync($"{Constantes.urlBase}/Citas/{cita.idCita}", data))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("No fue posible traer las citas: " + response.StatusCode);
                    }
                }
            }
        }

        public static async Task<bool> CrearCita(Cita cita)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(cita);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync($"{Constantes.urlBase}/Citas", data))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
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
