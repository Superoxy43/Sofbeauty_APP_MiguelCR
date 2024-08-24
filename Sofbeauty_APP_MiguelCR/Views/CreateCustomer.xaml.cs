using Microsoft.Maui;
using Sofbeauty_APP_MiguelCR.ViewModels;

namespace Sofbeauty_APP_MiguelCR.Views;

public partial class CreateCustomer : ContentPage
{

    //definición del objeto viewmodel que gestiona la página

    CustomerViewModel? vm;
    public CreateCustomer()
	{
		InitializeComponent();
        BindingContext = vm = new CustomerViewModel();
    }

    private async void BtnCancelCustomer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void BtnAddCustomer_Clicked(object sender, EventArgs e)
    {
        //TODO: debemos hacer una validación para los campos que son requisito

        var answer = await DisplayAlert("Confirmation Required", "Adding new customer. Are you sure?", "Yes", "No");

        if (answer)
        {

            bool R = await vm.VmAddCustomer(TxtCustomerName.Text.Trim(),
                                  TxtAddress.Text.Trim(),
                                  TxtPhoneNumber.Text.Trim(),
                                  TxtEmail.Text.Trim(),
                                  TxtPassword.Text.Trim());

            if (R)
            {
                await DisplayAlert(":)", "Customer added!!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Error: ", "OK");
            }

        }
    }
}