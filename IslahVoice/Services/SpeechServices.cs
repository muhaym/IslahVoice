using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IslahVoice.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace IslahVoice.Services
{
    class SpeechServices
    {
        public async Task<IEnumerable<Post>> GetSpeeches(string parameters)
        {
            var propery;
            if(parameters = "latestspeeches")
            {

            }
         //   IEnumerable<RootObject> posts = Enumerable.Empty<RootObject>();
            IEnumerable<Post> posts = Enumerable.Empty<Post>();
            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync("latestspeeches.php").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                       var tempe = await Task.Run(() =>
                           JsonConvert.DeserializeObject<RootObject>(json)
                        ).ConfigureAwait(false);
                        posts = tempe.rposts;
                    }
                }
            }

            return posts.ToList();
        }
        private const string ApiBaseAddress = "http://islahvoice.com/json/";
        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAddress)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
