using Sofbeauty_APP_MiguelCR.ViewModels;
namespace Sofbeauty_APP_MiguelCR.Views;

public partial class CreateProduct : ContentPage
{

    //definición del objeto viewmodel que gestiona la página

    ProductViewModel? vm;

    public CreateProduct()
	{
		InitializeComponent();
        BindingContext = vm = new ProductViewModel();
    }

    private async void BtnAddProduct_Clicked(object sender, EventArgs e)
    {
        //TODO: debemos hacer una validación para los campos que son requisito

        var answer = await DisplayAlert("Confirmation Required", "Adding new product. Are you sure?", "Yes", "No");

        if (answer)
        {

            bool R = await vm.VmAddProduct(TxtProductsName.Text.Trim(),
                                  TxtDescription.Text.Trim(),
                                  TxtType.Text.Trim(),
                                  Convert.ToDecimal(TxtPrice.Text.Trim()),
                                  TxtImg.Text.Trim(),
                                  Convert.ToInt32(TxtStock.Text.Trim()));

            if (R)
            {
                await DisplayAlert(":)", "Product added!!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Error: ", "OK");
            }

        }
    }

    private async void BtnCancelProduct_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}