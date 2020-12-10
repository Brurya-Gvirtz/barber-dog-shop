using System;

namespace BarberShop.Entities
{
    public class Queue : BaseEntity
    {
        public string CustomerID { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Customer Customer { get; set; }
    }
}