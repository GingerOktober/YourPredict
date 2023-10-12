using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace App.Models
{
    [Table ("Favorite")]
    public class Favorit
    {
        [Key]  
        public int GoodFavoriteId { get; set; }
        public int GoodId { get; set;}
        public int UserId { get; set; }
    }
}
