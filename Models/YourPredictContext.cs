using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class YourPredictContext : DbContext
    {
        public DbSet<Cards> Taro_Cards { get; set; } = null!;
        public DbSet<Orderss> Orders { get; set; } = null!;
        public DbSet<Goodss> Goods { get; set; } = null!;
        public DbSet<Carts> Cart { get; set; } = null!;
        public DbSet<Userss> Users { get; set; } = null!;
        public DbSet<Favorit> Favorite { get; set; } = null!;
        public DbSet<Commentss> Comments { get; set; } = null!;
        public YourPredictContext(DbContextOptions options) : base(options) { }
    }
}