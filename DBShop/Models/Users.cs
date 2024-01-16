using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBShop.Models
{
    [Table(nameof(DBShop.users))]
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Rule { get; set; }
        public string Username { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
