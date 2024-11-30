using CRUD_MVVM_Q42024.Models;
using CRUD_MVVM_Q42024.ViewModels;

namespace CRUD_MVVM_Q42024.Views;

public partial class AddEmpleadoView : ContentPage
{
	private AddEmpleadoViewModel viewModel;
	public AddEmpleadoView()
	{
		InitializeComponent();
		viewModel = new AddEmpleadoViewModel();
		BindingContext = viewModel;
	}

	public AddEmpleadoView(Empleado empleado)
	{
        InitializeComponent();
        viewModel = new AddEmpleadoViewModel(empleado);
        BindingContext = viewModel;
    }
}