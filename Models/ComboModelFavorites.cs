using NuGet.Configuration;

namespace App.Models
{
    public class ComboModelFavorites
    {
        public IEnumerable<Goodss> GoodsData { get; set; } = null!;
        public IEnumerable<Favorit> FavoritData { get; set; } = null!;
        public int UserId { get; set; }

    }
}
