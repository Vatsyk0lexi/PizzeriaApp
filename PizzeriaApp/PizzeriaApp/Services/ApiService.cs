using Newtonsoft.Json;
using PizzeriaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PizzeriaApp.Services
{
    public class ApiService
    {
        public string Url { get; set; } = "http://192.168.1.61:16161/api/Auth/";
        public async Task<bool> RegisterAsync(string email, string password, string username, string numberPhone)
        {
            using (var client = new HttpClient())
            {
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
                var responce = await client.PostAsync(Url + "register", httpContent);

                return responce.IsSuccessStatusCode;
            }
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            
            RegisterViewModel user = new RegisterViewModel()
            {
                Password = password,
                Email = email
            };
            var json = JsonConvert.SerializeObject(user);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, Url + "login");
            request.Content = httpContent;
            using (var client = new HttpClient())
            {

                var responce = await client.SendAsync(request);
                if (responce.IsSuccessStatusCode)
                {

                    App.Current.Properties["IsLoggedIn"] = Boolean.TrueString;
                    string token = await responce.Content.ReadAsStringAsync();
                    App.Current.Properties["Token"] = token;
                    App.Token = token;

                    var CurrentUser = await GetUserAsync(token);
                    App.Current.Properties["UserDetails"] = JsonConvert.SerializeObject(CurrentUser);
                    App.CurrentUser = CurrentUser;
                }
                return responce.IsSuccessStatusCode;
            }
        }

        public async Task<User> GetUserAsync(string token)
        {
            var httpClient = new HttpClient();
            using (var requestMessage =
            new HttpRequestMessage(HttpMethod.Get, Url+"GetUser"))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var responce =  await httpClient.SendAsync(requestMessage);
                responce.EnsureSuccessStatusCode();
                var strContent = await responce.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(strContent);
                return user;
            }
        }

        public async Task<bool> UpdateAsync(RegisterViewModel currentUser)
        {
            try
            {
                var httpClient = new HttpClient();
                using (var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, Url + "update"))
                {
                    requestMessage.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", App.Token);

                    var json = JsonConvert.SerializeObject(currentUser);
                    HttpContent httpContent = new StringContent(json);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    requestMessage.Content = httpContent;
                    var responce = await httpClient.SendAsync(requestMessage);
                    responce.EnsureSuccessStatusCode();

                    var strContent = await responce.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(strContent);

                    App.Current.Properties["UserDetails"] = JsonConvert.SerializeObject(user);
                    App.CurrentUser = user;

                    return responce.IsSuccessStatusCode;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
