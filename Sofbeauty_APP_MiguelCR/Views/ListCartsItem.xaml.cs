namespace Sofbeauty_APP_MiguelCR.Views;

public partial class ListCartsItem : ContentPage
{
	public ListCartsItem()
	{
		InitializeComponent();
	}

    private async void BtnAddItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateCartsItem());
    }

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}