
using System.ComponentModel.DataAnnotations.Schema;


namespace DBShop.Models
{
    [Table(nameof(DBshop.users))]
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
