using Sofbeauty_APP_MiguelCR.ViewModels;
using Sofbeauty_APP_MiguelCR.Models;

namespace Sofbeauty_APP_MiguelCR.Views;

public partial class CreateCartsItem : ContentPage
{
    //definición del objeto viewmodel que gestiona la página

    CartsItemViewModel? vm;
    public CreateCartsItem()
	{
		InitializeComponent();
        BindingContext = vm = new CartsItemViewModel();
        LoadShoppingCartList();
        LoadProductList();
    }

    private async void LoadShoppingCartList()
    {
        LstCarts.ItemsSource = await vm.VmGetShoppingCartsAsync();
    }


    private async void LoadProductList()
    {
        LstProducts.ItemsSource = await vm.VmGetProductsAsync();
    }

    private async void BtnAddCartsItem_Clicked(object sender, EventArgs e)
    {
        //TODO: debemos hacer una validación para los campos que son requisito

        var answer = await DisplayAlert("Confirmation Required", "Adding new Cart Item. Are you sure?", "Yes", "No");

        if (answer)
        {
            //extraer el objeto de tipo Shoppingcart seleccionado en el picker (lista)
            ShoppingCart selectedShoppingCart = LstCarts.SelectedItem as ShoppingCart;
            Product selectedProduct = LstProducts.SelectedItem as Product;

            bool R = await vm.VmAddCartsItem(selectedShoppingCart.CartsId,
                                  selectedProduct.ProductsId, 
                                  Convert.ToInt32(TxtQuantity.Text.Trim()));
                                  

            if (R)
            {
                await DisplayAlert(":)", "Item added!!", "OK");
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