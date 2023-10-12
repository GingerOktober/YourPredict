using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace App.Models
{
    [Table("Orders")]
    public class Orderss
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int GoodId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = "";
        public DateTime OrderDate { get; set; }
        public string DeliveryDate { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Payment { get; set; } = "";
    }
}