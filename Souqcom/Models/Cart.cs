using System;
using System.Collections.Generic;

#nullable disable

namespace Souqcom.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Qty { get; set; }

        public virtual Product Product { get; set; }
    }
}
