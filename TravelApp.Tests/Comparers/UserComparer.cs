using System.Diagnostics.CodeAnalysis;
using TravelApp.Domain.Models;

namespace TravelApp.Tests.Comparers;

public class UserComparer : IEqualityComparer<User>
{
    public bool Equals(User? user1, User? user2)
    {
        return user1?.Name == user2?.Name &&
               user1?.IconPath == user2?.IconPath &&
               user1?.EmailOrPhoneNumber == user2?.EmailOrPhoneNumber &&
               user1?.Password == user2?.Password;
    }

    public int GetHashCode([DisallowNull] User user)
    {
        return 0;
    }
}
