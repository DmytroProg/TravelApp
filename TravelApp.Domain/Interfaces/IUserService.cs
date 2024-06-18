using TravelApp.Domain.Models;

namespace TravelApp.Domain.Interfaces;

public interface IUserService
{
    void Register(User user);
    void Login(string emailOrPhone, string password);
    User GetInfo(int userId);
    User ChangeInfo(User user);
    List<FlightOrder> GetRecentOrders(int userId);
}
