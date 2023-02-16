using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKeyShop.Shared.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Owner { get; set; } = string.Empty;
        [Required]
        public string Number { get; set; } = string.Empty;
        [Required]
        public int CVV { get; set; }
        [Required]
        public string ExpirationDate { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
