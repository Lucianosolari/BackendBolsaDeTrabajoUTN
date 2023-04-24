namespace BackendBolsaDeTrabajoUTN.Models
{
    public class AddOfferRequest
    {
        public string OfferDescription { get; set; }
        public string? Style { get; set; }
        public int MeetId { get; set; }
    }
}
