using PlantasTest01.Clases;
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
    public partial class PaginaListaEnfermedades : ContentPage
    {
        public PaginaListaEnfermedades()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lsvEnfermedades.ItemsSource = await App.AzureService.ObtenerEnfermedad();
        }

        private void lsvEnfermedades_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Enfermedades enfermedad = e.SelectedItem as Enfermedades;
                PaginaEnfermedad pagina = new PaginaEnfermedad();
                pagina.ID = enfermedad.Id;
                Navigation.PushAsync(pagina);
            }
        }

        void btnNuevo_Click(object sender, EventArgs a)
        {
            Navigation.PushAsync(new PaginaEnfermedad());
        }
    }
}

