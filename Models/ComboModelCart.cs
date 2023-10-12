namespace App.Models
{
    public class ComboModelCart
    {
        public IEnumerable<Goodss> GoodsData { get; set; } = null!;
        public IEnumerable<Carts> CartData { get; set; } = null!;
        public int UserId { get; set; }
    }
}
