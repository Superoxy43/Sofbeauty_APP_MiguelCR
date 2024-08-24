using Sofbeauty_APP_MiguelCR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofbeauty_APP_MiguelCR.ViewModels
{
    public class CartsItemViewModel : BaseViewModel
    {

        public ShoppingCart MyShoppingCart { get; set; }
        public CartsItem MyCartsItem { get; set; }

        public Product myProduct { get; set; }

        public CartsItemViewModel()
        {
            MyShoppingCart = new ShoppingCart();
            MyCartsItem = new CartsItem();
            myProduct = new Product();
        }

        //función que carga los datos de los ShoppingCarts para mostrar en listas
        public async Task<List<ShoppingCart>?> VmGetShoppingCartsAsync()
        {
            try
            {
                List<ShoppingCart>? carts = new List<ShoppingCart>();

                carts = await MyShoppingCart.GetShoppingCartsAsync();

                if (carts == null) return null;
                return carts;


            }
            catch (Exception)
            {

                throw;
            }

        }

        //función que carga los datos de los Products para mostrar en listas
        public async Task<List<Product>?> VmGetProductsAsync()
        {
            try
            {
                List<Product>? products = new List<Product>();

                products = await myProduct.GetProductsAsync();

                if (products == null) return null;
                return products;


            }
            catch (Exception)
            {

                throw;
            }

        }

        //función para agregar items al carrito de compras
        public async Task<bool> VmAddCartsItem(int pCartsId,
                                          int pProductsId,
                                          int pQuantity)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyCartsItem = new()
                {
                    CarritoId = pCartsId,
                    ProductoId = pProductsId,
                    Cantidad = pQuantity
                };

                bool Ret = await MyCartsItem.AddCartsItemAsync();

                return Ret;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            { IsBusy = false; }
        }

    }
}
