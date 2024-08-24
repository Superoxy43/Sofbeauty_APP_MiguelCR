namespace Sofbeauty_APP_MiguelCR.Views;

public partial class ListCustomer : ContentPage
{
	public ListCustomer()
	{
		InitializeComponent();
	}

    private async void BtnCreateCustomer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateCustomer());
    }

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}