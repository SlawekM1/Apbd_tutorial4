using System;

namespace LegacyApp
{
    public class Client
    {
        public string Name { get; }
        public int ClientId { get; }
        public string Email { get; }
        public string Address { get; }
        public string Type { get; }

        public Client(int clientId, string name, string address, string email, string type)
        {
            ClientId = clientId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}