using BarberShop.Context;
using BarberShop.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BarberShop.DAL
{
    public class CustomerRepository
    {
        private static DatabaseContext db = new DatabaseContext();

        public static Customer AddCustomer(Customer data)
        {
            Customer customer = new Customer() { Name = data.Name, UserName = data.UserName, Password = data.Password };
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer;
        }
        public static bool IsCustomerExists(string userName)
        {
            return db.Customers.Count(c => c.UserName == userName) > 0;
        }
        public static Customer FindCustomer(string userName, string password)
        {
            return db.Customers.FirstOrDefault(c => c.UserName == userName && c.Password == password);
        }
        public static Customer GetCustomerById(string id)
        {
            return db.Customers.FirstOrDefault(h => h.Id == id);
        }
        public static Customer GetCustomerByName(string name)
        {
            return db.Customers.FirstOrDefault(h => h.UserName==name);
        }

    }
}
