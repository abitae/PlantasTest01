using System;
using System.Collections.ObjectModel;

namespace PlantasTest01.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            LoadMenu();
        }

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();
            Menu.Add(new MenuItemViewModel()
            {
                Icon="ic_shortcut_save.png",
                Title="Enfermedades",
                PageName= "PaginaListaEnfermedades"

            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_shortcut_save",
                Title = "Hierbas y Productos",
                PageName = "PaginaListaEnfermedades"

            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_shortcut_save",
                Title = "Consultas",
                PageName = "PaginaListaEnfermedades"

            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_shortcut_save",
                Title = "Ubicacion",
                PageName = "PaginaListaEnfermedades"

            });
        }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
    }
}
