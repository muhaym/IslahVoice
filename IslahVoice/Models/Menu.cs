using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IslahVoice.Models
{
    class Menu
    {
        public Menu(string name, Func<ContentPage> pageFn)
        {
            Title = name;
            PageFn = pageFn;
        }
        public string Title { get; set; }
        public Func<ContentPage> PageFn { get; set; }
    }
}
