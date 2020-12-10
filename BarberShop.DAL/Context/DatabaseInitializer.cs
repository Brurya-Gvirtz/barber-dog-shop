using BarberShop.Entities;
using System.Data.Entity;

namespace BarberShop.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);


            //var customer1 = new Customer() { Name = "Avraham", UserName = "Avraham123", Password = "123" };
            //var customer2 = new Customer() { Name = "Izchak", UserName = "Izchak456", Password = "456" };
            //var customer3 = new Customer() { Name = "Yaakov", UserName = "Yaakov789", Password = "789" };

            //context.Customers.Add(customer1);
            //context.Customers.Add(customer2);
            //context.Customers.Add(customer3);

            context.SaveChanges();
        }
    }
}