using TravelApp.Domain.Models;

namespace TravelApp.Domain.Interfaces;

public interface IUserService
{
    void Register(User user);
    User Login(string name, string password);
    User GetInfo(string name);
    User ChangeInfo(string name, User user);
    List<FlightOrder> GetRecentOrders(string name);
    bool UserExists(string name);
}
