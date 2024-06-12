namespace TravelApp.Domain.Models;

[Serializable]
public class User
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public string EmailOrPhoneNumber { get; set; }
    public string Password { get; set; }
    public string IconPath { get; set; }
}
