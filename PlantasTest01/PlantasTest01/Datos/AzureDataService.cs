using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using PlantasTest01.Clases;
using System.Linq;


namespace PlantasTest01.Datos
{
    public class AzureDataService
    {

        public MobileServiceClient MobileService { get; set; }
        IMobileServiceSyncTable<Enfermedades> tablaEnfermedades;

        bool isInitialized;

        public async Task Initialize()
        {
            if (isInitialized)
                return;

            MobileService = new MobileServiceClient("http://plantastest01.azurewebsites.net");

            const string path = "syncstore-Enfermedades.db";

            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<Enfermedades>();
            await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            tablaEnfermedades = MobileService.GetSyncTable<Enfermedades>();
            isInitialized = true;
        }

        public async Task<IEnumerable<Enfermedades>> ObtenerEnfermedad()
        {
            await Initialize();
            await SyncEnfermedades();
            return await tablaEnfermedades.OrderBy(a => a.Nombre).ToEnumerableAsync();
        }

        public async Task<Enfermedades> ObtenerEnfermedad(string id)
        {
            await Initialize();
            await SyncEnfermedades();
            return (await tablaEnfermedades.Where(a => a.Id == id).Take(1).ToEnumerableAsync()).FirstOrDefault();
        }

        public async Task<Enfermedades> AgregarEnfermedad(string nombre, string definicion, string causas, string tratamiento)
        {
            await Initialize();

            var item = new Enfermedades
            {
                Nombre = nombre,
                Definicion = definicion,
                Causas = causas,
                
                Tratamiento = tratamiento,
               
            };

            await tablaEnfermedades.InsertAsync(item);

            await SyncEnfermedades();
            return item;
        }

        public async Task<Enfermedades> ModificarEnfermedad(string id, string nombre, string definicion, string causas, string tratamiento)
        {
            await Initialize();

            var item = await ObtenerEnfermedad(id);
            item.Nombre = nombre;
            item.Definicion = definicion;
            item.Causas = causas;
            item.Tratamiento = tratamiento;
           

            await tablaEnfermedades.UpdateAsync(item);

            await SyncEnfermedades();
            return item;
        }

        public async Task EliminarEnfermedad(string id)
        {
            await Initialize();

            var item = await ObtenerEnfermedad(id);

            await tablaEnfermedades.DeleteAsync(item);

            await SyncEnfermedades();
        }

        public async Task SyncEnfermedades()
        {
            await tablaEnfermedades.PullAsync("Enfermedades", tablaEnfermedades.CreateQuery());
            await MobileService.SyncContext.PushAsync();
        }
    }
}
