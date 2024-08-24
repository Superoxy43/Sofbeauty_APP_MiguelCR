namespace Sofbeauty_APP_MiguelCR.Views;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
	}

    private async void Catalog_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CatalogPage());
    }

    private async void Product_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListProduct());
    }

    private async void Customer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListCustomer());
    }
}