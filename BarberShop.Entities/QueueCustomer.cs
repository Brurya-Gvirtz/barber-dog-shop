using System;

namespace BarberShop.Entities
{
    public class QueueCustomer:BaseEntity
    {
        public DateTime ArrivalTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
    }
}
