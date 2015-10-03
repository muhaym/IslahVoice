using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IslahVoice.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace IslahVoice.Services
{
    class SpeechServices
    {
        public async Task<IEnumerable<Post>> GetSpeeches(Parameters param)
        {
            string passvalue=null;
            if (param.type == "LatestSpeech")
            {
                passvalue = "latestspeeches.php?start=" + param.start + "&limit=" + param.limit;
            }
            else if (param.type == "SearchSpeeches")
            {
                passvalue = "search.php?searchstring=" + param.searchstring + "&start=" + param.start + "&limit=" + param.limit;
            }
            else if(param.type == "SpeechbyCategory")
            {
                passvalue = "itemsbycategory.php?catid="+param.catid +"&start=" + param.start + "&limit=" + param.limit;
            }
          
         //   IEnumerable<RootObject> posts = Enumerable.Empty<RootObject>();
            IEnumerable<Post> posts = Enumerable.Empty<Post>();
            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync(passvalue).ConfigureAwait(false);
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
