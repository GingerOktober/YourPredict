namespace App.Models
{
    public class GoodWithFavoriteFlag
    {
        public Goodss GoodsData { get; set; }
        public bool IsFavorite { get; set; }
        public int UserId { get; set; }
    }
}
