using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ClientManagerApp
{
    public class ClientsViewModel : BaseViewModel
    {
        public ObservableCollection<Client> Items { get; set; }
        public Command LoadClientsCommand { get; set; }

        public ClientsViewModel()
        {
            Title = "Clientes";
            Items = new ObservableCollection<Client>();
            LoadClientsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewClientPage, Client>(this, "AddItem", async (obj, item) =>
            {
                var client = item as Client;
                Items.Add(client);
                await ClientData.AddItemAsync(client);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await ClientData.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
