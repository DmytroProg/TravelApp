namespace TravelApp.Domain.Models;

[Serializable]
public class Payment
{
    public string CardNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int CVV { get; set; }
}
