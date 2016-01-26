using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IslahVoice.Models;
using IslahVoice.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace IslahVoice.ViewModels
{
    
    class SpeechPageViewModel 
    {
        public string ptype { get; set; }
        public string start
        {
            get; set;
        }
        public List<Post> Speeches { get; set; }

        public SpeechPageViewModel()
        {
            ptype = "SearchSpeeches";
            start = "2";
            var content = "anas";
            if (ptype == "LatestSpeech")
            {
                Parameters param = new Parameters();
                param.ptype = "LatestSpeech";
                param.start = start;
                param.limit = "15";
                GetRemoteSpeeches(param).ConfigureAwait(false);
            }
            else if (ptype == "SearchSpeeches")
            {
                Parameters param = new Parameters();
                param.ptype = "SearchSpeeches";
                param.start = start;
                param.limit = "15";
                param.searchstring = content;
                GetRemoteSpeeches(param).ConfigureAwait(false);
            }
            else if (ptype == "SpeechbyCategory")
            {
                Parameters param = new Parameters();
                param.ptype = "SpeechbyCategory";
                param.start = start;
                param.limit = "15";
                param.searchstring = content;
                GetRemoteSpeeches(param).ConfigureAwait(false);
            }
        }
     

        private async Task GetRemoteSpeeches(Parameters param)
        {
            var remoteClient = new SpeechServices();
            var posts = await remoteClient.GetSpeeches(param).ConfigureAwait(false);
            this.Speeches = posts.ToList();
        }
    }
}
