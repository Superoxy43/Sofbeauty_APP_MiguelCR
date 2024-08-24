using Sofbeauty_APP_MiguelCR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofbeauty_APP_MiguelCR.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {

        public Customer MyCustomer { get; set; }

        public CustomerViewModel()
        {
            MyCustomer = new Customer();
        }

        //función para agregar producto
        public async Task<bool> VmAddCustomer(string pCustomersName,
                                                string pAddress,
                                                string pPhoneNumber,
                                                string pEmail,
                                                string pPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyCustomer = new()
                {
                    CNombre = pCustomersName,
                    Direccion = pAddress,
                    Telefono = pPhoneNumber,
                    Correo = pEmail,
                    Contrasennia = pPassword
                };

                bool Ret = await MyCustomer.AddCustomerAsync();

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
