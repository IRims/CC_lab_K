
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Order
    {
        public int OrdId { get; set; }
        public string CusName { get; set; }
        public int Laptop { get; set; }
        public int LCD { get; set; }
        public int Phone { get; set; }

    }
}