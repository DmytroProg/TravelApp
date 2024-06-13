namespace TravelApp.Domain.Models;

[Serializable]
public class Payment
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int CVV { get; set; }
}
