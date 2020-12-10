using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        //[Key,Column(Order=1)]
        public string UserName { get; set; }
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Password must meet requirements")]
        public string Password { get; set; }
    }
}