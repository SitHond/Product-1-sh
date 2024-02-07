using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBShop.Models
{
    [Table(nameof(DBshop.orders))]
    public class Orders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        public string ListOrders { get; set; }
        public DateTime DateOrders { get; set; }
        public DateTime DateTrasit { get; set; }
        public int Punkt { get; set; }
        public string UsernameClients { get; set; }
        public int CodeP { get; set; }
        public string Status { get; set; }
    }
}
