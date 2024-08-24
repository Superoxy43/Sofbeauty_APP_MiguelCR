namespace Sofbeauty_APP_MiguelCR.Views;

public partial class CatalogPage : ContentPage
{
	public CatalogPage()
	{
		InitializeComponent();
	}

    private async void BtnCartsItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListCartsItem());
    }

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}