using System;
using ClientManagerApp.Views;
using Xamarin.Forms;

namespace ClientManagerApp
{
    public partial class ClientsPage : ContentPage
    {
        readonly ClientsViewModel _clientsViewModel;

        public IClientData<Client> ClientData => DependencyService.Get<IClientData<Client>>() ?? new ClientData();

        public ClientsPage()
        {
            InitializeComponent();

            _clientsViewModel = new ClientsViewModel();

            BindingContext = _clientsViewModel;
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var client = new Client();
            client = (Client)args.SelectedItem;
            if (client == null)
            {
                return;
            }

            await Navigation.PushAsync(new ClientDetailPage(client) { Title = client.Name });

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        public async void AddClient_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewClientPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_clientsViewModel.Items.Count == 0)
            {
                _clientsViewModel.LoadClientsCommand.Execute(null);
            }
        }

        public async void EditButton_OnClicked(object sender, EventArgs e)
        {
            var eventHandler = (Button)sender;

            var clientId = eventHandler.CommandParameter;

            var client = ClientData.GetItemAsync(int.Parse(clientId.ToString())).Result;

            await Navigation.PushAsync(new EditClientPage(client));
        }

        public async void DeleteButton_OnClicked(object sender, EventArgs e)
        {
            var eventHandler = (Button)sender;

            var clientId = eventHandler.CommandParameter;

            var client = ClientData.GetItemAsync(int.Parse(clientId.ToString())).Result;

            var answer = await DisplayAlert("Confirmar Eliminación", "¿Quieres eliminar a " + client.Name + "?", "Sí", "No");

            if (answer)
            {
                await ClientData.DeleteItemAsync(client.ClientId);
                await Navigation.PushAsync(new ClientsPage());
            }
        }
    }
}