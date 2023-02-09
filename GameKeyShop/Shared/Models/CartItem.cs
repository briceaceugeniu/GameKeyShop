using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKeyShop.Shared.Models
{
    public class CartItem
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int PlatformTypeId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
