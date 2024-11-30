
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD_MVVM_Q42024.Models;
using CRUD_MVVM_Q42024.Services;

namespace CRUD_MVVM_Q42024.ViewModels
{
    public partial class AddEmpleadoViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;
        
        [ObservableProperty]
        private string direccion;
        
        [ObservableProperty]
        private string email;

        private readonly EmpleadoService empleadoService;

        public AddEmpleadoViewModel()
        {
            empleadoService = new EmpleadoService();
        }

        public AddEmpleadoViewModel(Empleado empleado)
        {
            empleadoService = new EmpleadoService();
            Id = empleado.Id;
            Nombre = empleado.Nombre;
            Direccion = empleado.Direccion;
            Email = empleado.Email;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {

                Empleado empleado = new Empleado
                {
                    Id = Id,
                    Nombre = Nombre,
                    Direccion = Direccion,
                    Email = Email,
                };

                if (empleado.Nombre == null || empleado.Nombre == "")
                {
                    Alerta("ADVERTENCIA", "Ingrese el nombre completo.");
                } else
                {
                    if (Id == 0)
                    {
                        empleadoService.Insert(empleado);
                    }
                    else
                    {
                        empleadoService.Update(empleado);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }
    }
}
