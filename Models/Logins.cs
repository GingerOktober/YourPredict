using FluentMigrator.Infrastructure;
using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
namespace App.Models
{
    [Table("Users")]
    public class Logins
    {
        [NotMapped]
        public string Email { get; set; } = "";
        [NotMapped]
        public string Password { get; set; } = "";
    }
}
