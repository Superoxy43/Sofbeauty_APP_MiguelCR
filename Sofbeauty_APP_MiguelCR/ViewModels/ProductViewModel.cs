using Sofbeauty_APP_MiguelCR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofbeauty_APP_MiguelCR.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {

        public Product MyProduct { get; set; }

        public ProductViewModel()
        {
            MyProduct = new Product();
        }

        //función para agregar producto
        public async Task<bool> VmAddProduct(string pProductsName,
                                                string pDescription, 
                                                string pType, 
                                                decimal pPrice, 
                                                string Img, 
                                                int pStock)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyProduct = new()
                {
                    PNombre = pProductsName,
                    Descripcion = pDescription,
                    Tipo = pType,
                    Precio = pPrice,
                    Imagen = Img,
                    Existencias = pStock
                };

                bool Ret = await MyProduct.AddProductAsync();

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
