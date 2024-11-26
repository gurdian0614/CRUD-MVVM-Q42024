using CRUD_MVVM_Q42024.ViewModels;

namespace CRUD_MVVM_Q42024.Views;

public partial class MainEmpleadoView : ContentPage
{
	private MainEmpleadoViewModel viewModel;
	public MainEmpleadoView()
	{
		InitializeComponent();
		viewModel = new MainEmpleadoViewModel();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetAll();
    }
}