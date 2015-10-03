using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace IslahVoice.Helpers
{
    public class AttachmentList
    {
        public string attachmentID { get; set; }
        public string attachmentTitle { get; set; }
        public string attachmentFilename { get; set; }
    }

    public class Post
    {
        public string itemID { get; set; }
        public string item { get; set; }
        public List<AttachmentList> AttachmentList { get; set; }
    }

    public class RootObject
    {
        public List<Post> posts { get; set; }
    }

    static public class DataServices
    {
        
        static async Task GetDatafromServer(string paramater)
        {
         
            string responseString = null;
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                   {
                    { "number_of_posts", "10" },
                   };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("ttp://www.islahvoice.com/json/"+paramater+".php", content);
                responseString = await response.Content.ReadAsStringAsync();
            }

            if (responseString != null)
            {
                var temp = JsonConvert.DeserializeObject<RootObject>(responseString);

            }
        }
        
    }
}
