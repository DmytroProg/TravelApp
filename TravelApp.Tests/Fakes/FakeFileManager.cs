using System.Xml.Serialization;
using TravelApp.Storage.Interfaces;

namespace TravelApp.Tests.Fakes;

public class FakeFileManager : IFileManager, IDisposable
{
    private readonly string _path;

    public FakeFileManager(string path)
    {
        _path = path;
    }

    public void Dispose()
    {
        File.Delete(_path);
    }

    public List<T> ReadList<T>()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
        using(var fs = new FileStream(_path, FileMode.Open, FileAccess.Read))
        {
            return (List<T>)xmlSerializer.Deserialize(fs);
        }
    }

    public void Write<T>(List<T> list)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
        using (var fs = new FileStream(_path, FileMode.Open, FileAccess.Read))
        {
            xmlSerializer.Serialize(fs, list);
        }
    }
}
