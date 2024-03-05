using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Domain.Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string ProductName {  get; set; }
        public DateTime BuyTime { get; set; }


    }
}
