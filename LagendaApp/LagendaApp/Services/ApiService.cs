using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LagendaApp.Interfaces;
using LagendaApp.Models;
using LagendaApp.ViewModels;
using Newtonsoft.Json;

namespace LagendaApp.Services
{
    
        public class ApiService : IApiService
        {
            public async Task<Response> getUsuario(Usuario usuario)
            {

                try
                {


                    var jsonRequest = JsonConvert.SerializeObject(usuario);
                    var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(App.Current.Resources["UrlAPI"].ToString());

                    var url = "api/teste/Login";

                    var response = await client.PostAsync(url, httpContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            Message = "Usuário ou Senha Incorretos",

                        };

                    }

                    var result = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<Usuario>(result);

                    return new Response
                    {
                        IsSuccess = true,
                        Message = "login Ok",
                        Result = user
                    };

                }
                catch (Exception ex)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                    };
                    throw;
                }
            }


            
        }
    
}
