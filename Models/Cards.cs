using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("Taro_Cards")]
    public class Cards
    {

        [Key]
        public int CardId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Arcane { get; set; } = "";
        public string image_link { get; set; } = "";
        public string position { get; set; } = "";
    }
}
