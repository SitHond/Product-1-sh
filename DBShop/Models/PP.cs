
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBShop.Models
{
    [Table(nameof(DBshop.pp))]
    public class PP
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id_pp { get; set; }
        public ItemList itemList { get; set; }
        public Orders orders { get; set; }
    }
}
