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
            await App.Current!.MainPage!.Navigation.PushAsync(new MainEmpleadoView());
        }
    }
}
