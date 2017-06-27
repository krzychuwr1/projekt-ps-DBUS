using System;
using System.Threading.Tasks;
using Tmds.DBus;

namespace dbusTest
{
    class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: --session/--system <servicename> <objectpath>");
                return -1;
            }
            bool sessionNotSystem = args[0] != "--system";
            var service = args[1];
            var objectPath = args[2];
            Task.Run(() => InspectAsync(sessionNotSystem, service, objectPath)).Wait();
            return 0;
        }

        private static async Task InspectAsync(bool sessionNotSystem, string serviceName, string objectPath)
        {
            using (var connection = new Connection(sessionNotSystem ? Address.Session : Address.System))
            {
                await connection.ConnectAsync(OnDisconnect);
                var introspectable = connection.CreateProxy<IListNames>(serviceName, objectPath);
                var xml = await introspectable.ListNamesAsync();
                Console.WriteLine(xml);
            }
        }

        public static void OnDisconnect(Exception e)
        {
            if (e != null)
            {
                Console.WriteLine($"Connection closed: {e.Message}");
            }
        }

    }
}
