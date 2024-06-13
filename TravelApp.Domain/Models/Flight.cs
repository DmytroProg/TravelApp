namespace TravelApp.Domain.Models;

[Serializable]
public class Flight
{
    public int Id { get; set; }
    public string CompanyImagePath { get; set; }
    public Country CountryFrom { get; set; }
    public Country CountryTo { get; set; }
    public DateTime Date { get; set; }
    public int AdultsCount { get; set; }
    public int TripDuration { get; set; }
    public List<Supply> Supplies { get; set; }
}
