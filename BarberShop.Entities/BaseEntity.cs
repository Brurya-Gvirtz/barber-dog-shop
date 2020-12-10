using System;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Entities
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}