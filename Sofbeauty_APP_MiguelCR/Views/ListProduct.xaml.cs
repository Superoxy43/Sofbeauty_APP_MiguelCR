namespace Sofbeauty_APP_MiguelCR.Views;

public partial class ListProduct : ContentPage
{
	public ListProduct()
	{
		InitializeComponent();
	}

    private async void BtnCreateProduct_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateProduct());
    }

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}