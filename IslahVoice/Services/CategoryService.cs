using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IslahVoice.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IslahVoice.Helpers
{
    class CategoryService
    {
        public async Task<IEnumerable<Category>> GetCategories()
        {
            IEnumerable<Category> MainCategories = Enumerable.Empty<Category>();
            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync("categories.php").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var tempe = await Task.Run(() =>
                            JsonConvert.DeserializeObject<CategorySource>(json)
                         ).ConfigureAwait(false);
                        MainCategories = tempe.Categories;
                    }
                }
            }

            return MainCategories.ToList();
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
