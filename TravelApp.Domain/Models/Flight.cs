namespace TravelApp.Domain.Models;

[Serializable]
public class Flight
{
    // Unique
    public int Id { get; set; }
    public string CompanyImagePath { get; set; }
    public string CountryFrom { get; set; }
    public string CountryTo { get; set; }
    public DateTime Date { get; set; }
    public int AdultsCount { get; set; }
    public int TripDuration { get; set; }
    public List<string> Supplies { get; set; }
}
