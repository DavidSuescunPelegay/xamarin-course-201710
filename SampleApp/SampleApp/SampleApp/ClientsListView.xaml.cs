using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SampleApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientsListView : ContentPage
    {
        public List<Client> Items { get; set; }

        public static List<Client> _clients;

        public ClientsListView()
        {
            InitializeComponent();

            LoadData();

            Items = _clients;

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var client=new Client();
            client =(Client) e.Item;

            await DisplayAlert("Buenos dias "+client.Name, "Tu email es "+client.Email, "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;




            /*
             * var client = new Client();
            client = (Client)args.SelectedItem;
            if (client == null)
            {
                return;
            }

            await Navigation.PushAsync(new ClientDetailPage(client) { Title = client.Name });

            // Manually deselect item
            ItemsListView.SelectedItem = null;
             */
        }

        public void LoadData()
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

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var eventHandler = (Button) sender;
            var clientId = (int)eventHandler.CommandParameter;

            var client=_clients.First(c => c.ClientId == clientId);

            await Navigation.PushAsync(new EditClient(client));
        }
    }
}
