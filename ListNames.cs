using System.Threading.Tasks;
using Tmds.DBus;

[DBusInterface("org.freedesktop.DBus.ListNames")]

public interface IListNames : IDBusObject
{
    Task<string> ListNamesAsync();
}