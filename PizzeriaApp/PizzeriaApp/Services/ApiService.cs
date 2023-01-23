using Newtonsoft.Json;
using PizzeriaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaApp.Services
{
    public class ApiService
    {
        public string Url { get; set; } = "http://192.168.1.70:5215/api/Auth";
        public async Task<bool> RegisterAsync(string email, string password, string username, string numberPhone)
        {
            var client = new HttpClient();
            RegisterViewModel user = new RegisterViewModel()
            {
                Username = username,
                Password = password,
                Email = email,
                NumberPhone = numberPhone
            };
            var json = JsonConvert.SerializeObject(user);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responce = await client.PostAsync(Url + "/register", httpContent);

            return responce.IsSuccessStatusCode;
        }
    }
}
