using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace App.Models
{
    [Table("Goods")]
    public class Goodss
    {
        [Key]
        public int GoodId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Category { get; set; } = "";
        public int Price { get; set; }
        public int? Discount { get; set; }
        public int? Old_price { get; set; }
        public string image_link1 { get; set; } = "";
        public string? image_link2 { get; set; } = "";
        public string? image_link3 { get; set; } = "";
    }
}