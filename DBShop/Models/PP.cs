
using System.ComponentModel.DataAnnotations.Schema;

namespace DBShop.Models
{
    [Table(nameof(DBshop.pp))]
    public class PP
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nane { get; set; }
    }
}
