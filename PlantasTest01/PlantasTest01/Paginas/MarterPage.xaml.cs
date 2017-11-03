using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantasTest01.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarterPage : MasterDetailPage
    {
        public MarterPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Navigator = this.Navigator;
        }
    }
}