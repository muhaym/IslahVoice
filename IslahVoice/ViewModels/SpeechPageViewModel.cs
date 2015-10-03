using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IslahVoice.Models;
using IslahVoice.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace IslahVoice.ViewModels
{
    [ImplementPropertyChanged]
    class SpeechPageViewModel 
    {
        public List<Post> Speeches { get; set; }

        public SpeechPageViewModel()
        {
            GetRemoteSpeeches().ConfigureAwait(false);
        }
        public async Task GetSpeeches()
        {
       
   //         await GetRemoteSpeeches();
     
        }

        private async Task GetRemoteSpeeches()
        {
            Parameters param = new Parameters();
            param.type = "LatestSpeech";
            param.start = "0";
            param.limit = "15";

            var remoteClient = new SpeechServices();
            var posts = await remoteClient.GetSpeeches(param).ConfigureAwait(false);
            this.Speeches = posts.ToList();
        }
    }
}
