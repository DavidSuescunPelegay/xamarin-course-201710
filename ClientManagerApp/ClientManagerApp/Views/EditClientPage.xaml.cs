
using System;
using Xamarin.Forms;

namespace ClientManagerApp.Views
{
    public partial class EditClientPage : ContentPage
    {
        public Client Client{ get; set; }

        public IClientData<Client> ClientData => DependencyService.Get<IClientData<Client>>() ?? new ClientData();

        public EditClientPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public EditClientPage(Client client)
        {
            InitializeComponent();

            this.Client = client;

            BindingContext = Client;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopToRootAsync();

            var client = new Client
            {
                ClientId = int.Parse(editClientId.Text),
                Name = editName.Text,
                Email = editEmail.Text,
                City = editCity.Text,
                Country = editCountry.Text
            };

            await ClientData.UpdateItemAsync(client);

            await Navigation.PushAsync(new ClientsPage());
        }
    }
}
