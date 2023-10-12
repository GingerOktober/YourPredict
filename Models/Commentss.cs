using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table ("Comments")]
    public class Commentss
    {
        [Key]
        public int Commentid { get; set; } 
        public int GoodId { get; set; }
        public string? Text { get; set; } = "";
        public int UserId { get; set; }
        public DateTime DateCreate { get; set; }

    }
}
