
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using IslahVoice.Models;
using IslahVoice.Views;
namespace IslahVoice.ViewModels
{
        class MenuPageViewModel 
    
    {
        public List<Menu> MainMenu { get; set; }
       public MenuPageViewModel()
        {
            var temp = new List<Menu>();
            temp.Add(new Menu("Latest", () => new SpeechPage()));
            temp.Add(new Menu("Orators", () => new CategoryPage()));
            temp.Add(new Menu("Subjects", () => new CategoryPage()));
            temp.Add(new Menu("Search", () => new SearchPage()));

            this.MainMenu = temp;
        }


    }
}
