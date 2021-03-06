using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eshop.GraphQL.Data
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string? Name { get; set; }

        [Required]
        [StringLength(250)]
        public string? Password { get; set; }

        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string? Address { get; set; }

        public ICollection<UserOrder> UserOrders { get; set; } =
            new List<UserOrder>();
    }
}