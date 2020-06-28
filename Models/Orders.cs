using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetMVC_EF_TPT.Models
{
    public abstract class Orders
    {
        [Key]
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }
    }
}
