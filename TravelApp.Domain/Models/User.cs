namespace TravelApp.Domain.Models;

[Serializable]
public class User
{
    public string Name { get; set; }
    public string EmailOrPhoneNumber { get; set; }
    public string Password { get; set; }
    public string IconPath { get; set; }
}
