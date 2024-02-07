using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBShop.Models
{
    [Table(nameof(DBshop.userToItems))]
    public class UserToItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Users Users { get; set; }
        
        public ItemList Item { get; set; }
    }
}
