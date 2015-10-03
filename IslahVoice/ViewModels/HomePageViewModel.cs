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
    class HomePageViewModel 
    {
        public List<Post> LatestSpeeches { get; set; }

        public HomePageViewModel()
        {
            GetRemoteSpeeches().ConfigureAwait(false);
        }
        public async Task GetSpeeches()
        {
       
            await GetRemoteSpeeches();
     
        }

        private async Task GetRemoteSpeeches()
        {
            var remoteClient = new SpeechServices();
            var posts = await remoteClient.GetSpeeches().ConfigureAwait(false);
            this.LatestSpeeches = posts.ToList();
        }
    }
}
