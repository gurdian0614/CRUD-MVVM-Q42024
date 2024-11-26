using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD_MVVM_Q42024.Models;
using CRUD_MVVM_Q42024.Services;
using CRUD_MVVM_Q42024.Views;
using System.Collections.ObjectModel;

namespace CRUD_MVVM_Q42024.ViewModels
{
    public partial class MainEmpleadoViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Empleado> empleadoCollection = new ObservableCollection<Empleado>();

        private readonly EmpleadoService empleadoService;

        public MainEmpleadoViewModel()
        {
            empleadoService = new EmpleadoService();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var getAll = empleadoService.GetAll();

            if (getAll.Count > 0)
            {
                EmpleadoCollection.Clear();
                foreach (var empleado in getAll)
                {
                    EmpleadoCollection.Add(empleado);
                }
            }
        }

        [RelayCommand]
        private async Task GoToAddEmpleadoView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEmpleadoView());
        }

        [RelayCommand]
        private async Task SelectEmpleado(Empleado empleado)
        {
            try
            {
                const string ACTUALIZAR = "Actualizar";
                const string ELIMINAR = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if (res == ACTUALIZAR)
                {
                    //TODO agregar parametro al constructor
                    await App.Current.MainPage.Navigation.PushAsync(new AddEmpleadoView(empleado));
                }
                else if (res == ELIMINAR) {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR EMPLEADO", "¿Desea eliminar este empleado?", "Si", "No");

                    if (respuesta) {
                        int del = empleadoService.Delete(empleado);

                        if (del > 0) {
                            EmpleadoCollection.Remove(empleado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }
    }
}
