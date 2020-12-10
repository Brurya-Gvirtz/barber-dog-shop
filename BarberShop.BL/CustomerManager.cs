using BarberShop.DAL;
using BarberShop.Entities;

namespace BarberShop.BL
{
    public class CustomerManager
    {

        public static bool IsCustomerExist(string userName)
        {
            return CustomerRepository.IsCustomerExists(userName);
        }

        public static Customer FindCustomer(string userName,string password)
        {
            return CustomerRepository.FindCustomer(userName, password);
        }

        public static Customer AddCustomer(Customer Customer)
        {
            return CustomerRepository.AddCustomer(Customer);
        }

        public static Customer GetCustomerByName(string name)
        {
            return CustomerRepository.GetCustomerByName(name);
        }
        public static Customer GetCustomerById(string id)
        {
            return CustomerRepository.GetCustomerById(id);
        }
    }
}
