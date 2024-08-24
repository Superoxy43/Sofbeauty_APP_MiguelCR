using Sofbeauty_APP_MiguelCR.ViewModels;
using Sofbeauty_APP_MiguelCR.Models;

namespace Sofbeauty_APP_MiguelCR.Views;


public partial class UserSignUpPage : ContentPage
{
	//definición del objeto viewmodel que gestiona la página

	UserViewModel? vm;

	public UserSignUpPage()
	{
		InitializeComponent();

		BindingContext = vm = new UserViewModel();

		LoadUserRoleList();
	}

	private async void LoadUserRoleList()
	{
		LstUserRoles.ItemsSource = await vm.VmGetUserRolesAsync();
	}


    private async void BtnAdd_Clicked(object sender, EventArgs e)
    {
		//TODO: debemos hacer una validación para los campos que son requisito

		var answer = await DisplayAlert("Confirmation Required", "Adding new user. Are you sure?", "Yes", "No");

		if (answer)
		{
			//extraer el objeto de tipo user role seleccionado en el picker (lista)
			UserRole selectedUserRole = LstUserRoles.SelectedItem as UserRole;

			bool R = await vm.VmAddUser(TxtEmail.Text.Trim(),
								  TxtName.Text.Trim(),
								  TxtPhone.Text.Trim(),
								  TxtPassword.Text.Trim(),
								  selectedUserRole.UserRoleId);

			if (R)
			{
				await DisplayAlert(":)", "User added!!", "OK");
				await Navigation.PopAsync();
			}
			else
			{
				await DisplayAlert(":(", "Error: ", "OK");
			}
			
		}

    }

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}