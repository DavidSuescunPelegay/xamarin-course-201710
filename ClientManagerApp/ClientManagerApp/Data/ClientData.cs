using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(ClientManagerApp.ClientData))]
namespace ClientManagerApp
{
    public class ClientData : IClientData<Client>
    {
        private List<Client> _clients;

        // Start Singleton Pattern
        private static IClientData<Client> _clientData;

        private ClientData(IClientData<Client> clientData)
        {
            _clientData = clientData;
        }

        public static IClientData<Client> GetInstance(IClientData<Client> clientData)
        {
            if (_clientData == null)
            {
                _clientData = new ClientData(clientData);
            }
            return _clientData;
        }
        // End Singleton Pattern

        public ClientData()
        {
            _clients = new List<Client>
            {
                new Client
                {
                    City = "Zaragoza",
                    Name = "Pepe Perez",
                    Country = "España",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 1,
                    Email = "pepe.perez@gmail.com"
                },
                new Client
                {
                    City = "Huesca",
                    Name = "Maria Luisa Fernandez",
                    Country = "España",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 2,
                    Email = "m.luisa.fernandez@hotmail.com"
                },
                new Client
                {
                    City = "Teruel",
                    Name = "Antonio Sanchez",
                    Country = "España",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 3,
                    Email = "sanchez.antonio@yahoo.es"
                },
                new Client
                {
                    City = "Alcañiz",
                    Name = "Pedro Ruiz",
                    Country = "España",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 4,
                    Email = "pedroruiz@gmail.com"
                },
                new Client
                {
                    City = "Barbastro",
                    Name = "Lucia Perez",
                    Country = "España",
                    Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                    ClientId = 5,
                    Email = "lucia_perez@gmail.com"
                }
            };
        }

        public async Task<bool> AddItemAsync(Client item)
        {
            _clients.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Client item)
        {
            var _item = _clients.FirstOrDefault(arg => arg.ClientId == item.ClientId);
            _clients.Remove(_item);
            _clients.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var _item = _clients.FirstOrDefault(arg => arg.ClientId == id);
            _clients.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Client> GetItemAsync(int id)
        {
            return await Task.FromResult(_clients.FirstOrDefault(s => s.ClientId == id));
        }

        public async Task<IEnumerable<Client>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_clients);
        }
    }
}
