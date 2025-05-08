
namespace DomainLayer.Entities
{
    public class Item : BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Mileage { get; set; }
        public string ImageUrl { get; set; }

        // Clave foránea que apunta a Auction
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }

    }
}
