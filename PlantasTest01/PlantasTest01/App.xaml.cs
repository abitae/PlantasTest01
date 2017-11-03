using PlantasTest01.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PlantasTest01
{
    public partial class App : Application
    {
        public static AzureDataService AzureService;

        public static NavigationPage Navigator { get; internal set; }

        public App()
        {
            InitializeComponent();
            AzureService = new AzureDataService();
            MainPage = new Paginas.MarterPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
