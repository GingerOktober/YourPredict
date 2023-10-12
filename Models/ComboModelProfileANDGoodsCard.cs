namespace App.Models
{
    public class ComboModelProfileANDGoodsCard
    {
        public IEnumerable<Userss> UsersData { get; set; } = null!;
        public IEnumerable<Goodss> GoodsData { get; set; } = null!;
        public IEnumerable<Orderss> OrdersData { get; set; } = null!;
        public IEnumerable<Commentss> CommentData { get; set; } = null!;
        public int UserId { get; set; }
    }
}
