using System;

namespace PlantasTest01.Clases
{
    public class Enfermedades
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }
        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }
        public string Nombre { get; set; }
        public string Definicion { get; set; }
        public string Causas { get; set; }
        public string Tratamiento { get; set; }
   

    } 
}
