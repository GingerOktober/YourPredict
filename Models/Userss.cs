using Humanizer;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace App.Models
{
    [Table("Users")]
    public class Userss
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Поле Имя не может быть пустым.")]
        public string Name { get; set; } = "";
        [EmailAddress(ErrorMessage = "Почта указана некорректно.")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Пожалуйста, введите корректный email.")]

        [Required(ErrorMessage = "Поле Email не может быть пустым.")]
        public string Email { get; set; } = "";

        [RegularExpression(@"^[a-zA-Z0-9_.!#$@+-]+$", ErrorMessage = "Использованы недопустимые для пароля символы.")]
        [Required(ErrorMessage = "Поле Пароль не может быть пустым.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должен быть не короче {2} символов.", MinimumLength = 6)]
        public string Password { get; set; } = "";
        [NotMapped]
        [RegularExpression(@"^[a-zA-Z0-9_.!#$@+-]+$", ErrorMessage = "Использованы недопустимые для пароля символы.")]
        [Required(ErrorMessage = "Поле Пароль не может быть пустым.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string? confirmPassword { get; set; } = "";

        public DateTime BirthDate { get; set; }
        public string image_link { get; set; } = "";
        public string Element { get; set; } = "";
        public string Zodiac { get; set; } = "";
        public string TotemAnimal { get; set; } = "";
        public string ChinaAnimal { get; set; } = "";
        public string Gem { get; set; } = "";
        public string Tree { get; set; } = "";
        public string Flower { get; set; } = "";
        public string Planet { get; set; } = "";
        public int LuckyNumberPath { get; set; }
        public int LuckyNumberBirthDay { get; set; }
        public string? About { get; set; } = "";
    }
}
