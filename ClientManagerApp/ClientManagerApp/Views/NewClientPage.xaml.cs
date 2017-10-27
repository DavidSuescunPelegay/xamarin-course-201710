using System;

using Xamarin.Forms;

namespace ClientManagerApp
{
    public partial class NewClientPage : ContentPage
    {
        public Client Client { get; set; }

        public IClientData<Client> ClientData => DependencyService.Get<IClientData<Client>>() ?? new ClientData();

        public NewClientPage()
        {
            InitializeComponent();

            Client = new Client
            {
                City = "Alicante",
                Name = "Kasper Brown",
                Country = "Spain",
                Image = "http://person.eu/00general/img/coordinator_and_members/Sharon-Smit.png",
                ClientId = 1,
                Email = "curabitur.massa @ut.ca"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Añadir Cliente", Client);
            await Navigation.PopToRootAsync();

            var client = new Client
            {
                Name = newName.Text,
                Email = newEmail.Text,
                City = newCity.Text,
                Country = newCountry.Text
            };

            await ClientData.AddItemAsync(client);
        }
    }
}
