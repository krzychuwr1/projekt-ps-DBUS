using System.Threading.Tasks;
using Tmds.DBus;

[DBusInterface("org.freedesktop.DBus.Introspectable")]
public interface IIntrospectable : IDBusObject
{
    Task<string> IntrospectAsync();
}