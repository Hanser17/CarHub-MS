using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Auction : BaseEntity
    {
        public int ReservePrice { get; set; }

        public string Seller { get; set; }
        public string? Winner { get; set; }

        public int? SoldAmount { get; set; }
        public int? CurrentHighBid { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime AuctionEnd { get; set; }

        public Status Status { get; set; }

        // Navegación: relación 1:1 con Item
        public Item Item { get; set; }

    }
}
