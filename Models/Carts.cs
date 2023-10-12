using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("Cart")]
    public class Carts
    {
        [Key]
        public int GoodinCartId { get; set; }
        public int GoodId { get; set; }
        public int UserId { get; set; }
    }
}