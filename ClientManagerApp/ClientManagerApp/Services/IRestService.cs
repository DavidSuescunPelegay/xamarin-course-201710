using System.Collections.Generic;
using System.Threading.Tasks;
using ClientManagerApp;

namespace ClientManagerApp
{
	public interface IRestService
	{
		Task<List<Client>> RefreshDataAsync ();

		Task SaveTodoItemAsync (Client item, bool isNewItem);

		Task DeleteTodoItemAsync (int id);
	}
}
