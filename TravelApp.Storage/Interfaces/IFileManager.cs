namespace TravelApp.Storage.Interfaces;

public interface IFileManager
{
    void Write<T>(List<T> list);
    List<T> ReadList<T>();
}
