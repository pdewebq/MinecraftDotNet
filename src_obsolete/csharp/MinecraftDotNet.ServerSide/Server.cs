using System.Collections.Generic;
using MinecraftDotNet.Core;
using MinecraftDotNet.Core.Worlds;

namespace MinecraftDotNet.ServerSide
{
    public class Server : IServer
    {
        public Server()
        {
            Clients = new List<IClient>();
        }

        public IWorld CurrentWorld { get; }
        
        public IReadOnlyCollection<IClient> Clients { get; }
    }
}