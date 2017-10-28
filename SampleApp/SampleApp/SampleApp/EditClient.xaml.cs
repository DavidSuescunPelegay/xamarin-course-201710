using System;
using SampleApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp
{
    public partial class EditClient : ContentPage
    {
        public Client Client;

        public EditClient()
        {
            InitializeComponent();
        }

        public EditClient(Client client)
        {
            InitializeComponent();

            this.Client = client;

            BindingContext = Client;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var client = new Client();
            client.ClientId =int.Parse(editClientId.Text);
            client.Name = editName.Text;
            client.Email = editEmail.Text;
            client.City = editCity.Text;
            client.Country = editCountry.Text;

            ClientsListView._clients.Remove(client);
            ClientsListView._clients.Add(client);
        }
    }
}