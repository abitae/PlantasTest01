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
    public partial class PaginaEnfermedad : ContentPage
    {
        public string ID = "";

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (ID != "")
            {
                Enfermedades enfermedad = await App.AzureService.ObtenerEnfermedad(ID);
                txtNombre.Text = enfermedad.Nombre;
                txtDefinicion.Text = enfermedad.Definicion;
                txtCausas.Text = enfermedad.Causas;
                txtTratamiento.Text = enfermedad.Tratamiento;
               
            }
        }

        void btnGuardar_Click(object sender, EventArgs a)
        {
            string nombre = txtNombre.Text;
            string definicion = txtDefinicion.Text;
            string causas = txtCausas.Text;
            string tratamiento = txtTratamiento.Text;

            if (ID == String.Empty)
                App.AzureService.AgregarEnfermedad(nombre, definicion, causas, tratamiento);
            else
                App.AzureService.ModificarEnfermedad(ID, nombre, definicion, causas, tratamiento);
            Navigation.PopAsync();
        }

        void btnEliminar_Click(object sender, EventArgs a)
        {
            if (ID != "")
            {
                App.AzureService.EliminarEnfermedad(ID);
                Navigation.PopAsync();
            }
        }

        public PaginaEnfermedad()
        {
            InitializeComponent();
        }
    }
}
