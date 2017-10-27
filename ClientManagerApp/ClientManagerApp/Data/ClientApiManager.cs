using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManagerApp
{
	public class ClientApiManager
	{
		IRestService restService;

		public ClientApiManager (IRestService service)
		{
			restService = service;
		}

		public Task<List<Client>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}

		public Task SaveTaskAsync (Client client, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync (client, isNewItem);
		}

		public Task DeleteTaskAsync (Client client)
		{
			return restService.DeleteTodoItemAsync (client.ClientId);
		}
	}
}
