using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetMVC_EF_TPT.Models
{
    [Table("OrderDetail")]
    public class OrderDetail : Orders
    {
        public string orderedItem { set; get; }
        public string destAdress { set; get; }
        public int price { set; get; }
    }
}
