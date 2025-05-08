

namespace AplicationLayer.DTO_s
{
    public class SaveAuctonDto
    {
        public int ReservePrice { get; set; }
        public string Seller { get; set; }
        public DateTime AuctionEnd { get; set; }

        // Incluye los datos del item asociado
        public SaveItemDto Item { get; set; }

    }
}
