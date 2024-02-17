using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBShop.Models
{
    [Table(nameof(DBshop.itemLists))]
    public class ItemList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Tag { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string Izm { get; set; }
        public string Price { get; set; }
        public string Skid { get; set; }
        public string Manufacturer { get; set; }
        public string Provider { get; set; }
        public string Categoru { get; set; }
        public string SkidOn { get; set; }
        public int Count { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string Img { get; set; }
    }
}
