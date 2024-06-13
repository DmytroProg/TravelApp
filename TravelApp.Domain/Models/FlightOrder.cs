namespace TravelApp.Domain.Models;

[Serializable]
public class FlightOrder
{
    public int Id { get; set; }
    public Flight Flight { get; set; }
    public User User { get; set; }
    public DateTime PurchaseDate { get; set; }
    public Payment Payment { get; set; }
    public string UserName { get; set; }
    public string EmailOrPhoneNumber { get; set; }
}
