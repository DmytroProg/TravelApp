namespace TravelApp.Domain.Models;

[Serializable]
public class FlightOrder
{
    public int FlightId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public Payment Payment { get; set; }
    public string UserName { get; set; }
}
