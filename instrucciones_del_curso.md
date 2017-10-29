# Instrucciones del Curso

## Creación de la API

### Creación del **Proyecto**

Proyecto API con Identity (Individual User Accounts)

### Creación del **Modelo**

`Client.cs` (Clientes)

```c#
public class Client
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
```

### Creación del **Controlador**

Creamos un Controlador del tipo **Web API 2 Controller with actions, using Entity Framework**, esto nos generará un Controlador con las acciones básicas interactuando a la vez con Base de Datos.

```c#
public class ClientsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Clients
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> DeleteClient(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            await db.SaveChangesAsync();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.ClientId == id) > 0;
        }
    }
```

### Creación de la **Base de Datos**

En el menú de Visual Studio, vamos a (Tools/Nuget Package Manager/Package Manager Console).

```
PM> Enable-Migrations
```

Le damos a Enter y nos creará la carpeta Migrations con un archivo Configuration.cs, este archivo es el que utilizará Visual Studio para la configuración de los parámetros de la Base de Datos. El archivo debería ser algo así:

```c#
using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClientManagerApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClientManagerApi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
```

Nosotros podemos ejecutar unos métodos llamados semilla (seed), que nos servirán para agregar datos de prueba a la Base de Datos, estos datos deben pegarse en el metodo **Seed**, los datos que hemos utilizado en el curso son estos:

```c#
context.Clients.AddOrUpdate(
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
            );

            context.SaveChanges();
```

**IMPORTANTE:** No nos debemos olvidar de la última línea que es la que realmente ejecuta los cambios en la Base de Datos.

Para confirmar todos estos cambios ejecutamos en el **Package Manager Console** la siguiente instrucción:

```
PM> Update-Database -Verbose
```

Ahora si vamos a la pestaña de Server Explorer veremos en **DefaultConnection** como tenemos nuestra tabla de Clients y otras que la framework ha creado, estas tablas las ha creado la framework porque hemos elegido que queremos la autenticación por usuario individual (Individual User Account), que nos genera la tabla de Usuarios, Roles y sus respectivas tablas intermedias.



## Creación de la Aplicación Xamarin

Para la creación de la aplicación Xamarin nos vamos a Visual Studio y en el menú (File>New>Project), elegimos Cross-Platform y elegimos **Blank App: Xamarin**, en la siguiente pantalla elegimos: **Blank App**, **Xamarin.Forms** y **Portable Class Library (PCL)**, así tenemos una plantilla blanca para comenzar a trabajar, utilizamos los formularios de Xamarin, y en la elección de código la hacemos para que el código sea portable, si eligiéramos **Shared Project**, sería el proyecto más complicado ya que tendríamos que escribir el código según el Sistema Operativo.

Después de generar los proyectos vemos que tenemos 1 solución y dentro de ésta 4 proyectos (Portable, .Android, .iOS, .UWP), el primero es el código que va a ser compartido con todos los Sistemas Operativos con código C#, ya si quisiéramos utilizar tecnologías específicas, necesitaríamos meterlas en cada proyecto según el Sistema Operativo.

### Importación de paquetes NuGet:

Damos botón derecho en el nombre de la solución y elegimos la opción de **Manage NuGet Packages**, nos aparecerá una ventana con los paquetes NuGet, en la pestaña de **Updates** es recomendable que actualicemos todos los paquetes NuGet para contar siempre con las últimas versiones de los paquetes instalados.

Finalmente debemos irnos a la pestaña **Browse**, e instalar el paquete **Newtonsoft**, este paquete nos ayuda a convertir **strings JSON** en **objetos C#** y viceversa.

### Creación de carpetas

#### Carpeta `Data`: Contiene los datos, tanto de los clientes como los de acceso a la API.

##### Dentro de esta carpeta añadimos 4 ficheros C#:

###### `ClientApiManager.cs`: Clase encargada de llamar a la API.

```c#
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
```

###### `ClientData.cs`:

```c#
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
```

###### `Constants.cs`: Clase que contendrá los datos de acceso a la API (URL, usuario y contraseña).

```c#
public static class Constants
    {
        // URL of REST service
        public static string RestUrl = "http://localhost:64247";
    }
```

###### `IClientData.cs`: Interface que nos serviría para otros modelos que pudiésemos tener en nuestra aplicación, utiliza el tipo genérico `T` por esta misma razón.

```c#
public interface IClientData<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
```

#### Carpeta `Models`: Contiene los modelos que va a tener nuestra aplicación, es muy recomendable que tengan las mismas propiedades que los modelos de la API.

##### Dentro de esta carpeta añadimos el modelo `Client.cs`:

###### `Client.cs`:

```c#
public class Client
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
```

#### Carpeta `Services`: Contiene los servicios que llamarán a la API: 

##### Dentro de esta carpeta añadimos estos 2 ficheros C#:

###### `IRestService.cs`: Interface que nos serviría para utilizar con otros modelos:

```c#
Task<List<Client>> RefreshDataAsync ();

Task SaveTodoItemAsync (Client item, bool isNewItem);

Task DeleteTodoItemAsync (int id);
```

###### `RestService.cs`: Clase C# que implementa la interface anterior:

```c#
public class RestService : IRestService
    {
        HttpClient client;

        public List<Client> Items { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Client>> RefreshDataAsync()
        {
            Items = new List<Client>();

            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            using (var client = new HttpClient())
            {
                using (var res = await client.GetAsync(uri))
                {
                    using (var content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            Items = JsonConvert.DeserializeObject<List<Client>>(data);
                        }
                    }
                }
            }

            return Items;
        }

        public async Task SaveTodoItemAsync(Client item, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				TodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				TodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }
    }
```

#### Carpeta `ViewModels`: Contiene los modelos que vienen de las vistas y se pasan a los servicios:

##### Dentro de esta carpeta creamos los 3 ficheros C# que serán los que lleguen de las 3 vistas:

###### `BaseViewModel.cs`: Vista principal de las que heredarán el resto de vistas, contiene inyección de dependencias propia de Xamarin, para que no tengamos que obtener la instancia del objeto `ClientData`, ni por `new` ni por utilización del Patrón Singleton.

```c#
public class BaseViewModel : INotifyPropertyChanged
    {
        public IClientData<Client> ClientData => DependencyService.Get<IClientData<Client>>() ?? new ClientData();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
```

###### `ClientsViewModel.cs`: Vista que hereda de la vista `BaseViewModel`y que utiliza muchas de las propiedades.

```c#
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
```

###### `InformationViewModel.cs`: Vista de ejemplo, utilizamos el objeto `Command`para abrir una nueva pestaña en el navegador móvil.

```c#
public class InformationViewModel : BaseViewModel
    {
        public InformationViewModel()
        {
            Title = "Informacion";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/DavidSuescunPelegay/xamarin_course_201710")));
        }

        public ICommand OpenWebCommand { get; }
    }
```

#### Carpeta `Views`: Contiene todas las vistas que son las que se muestran al usuario:

##### Dentro de esta vista diferenciamos archivos `.xaml`y archivos `.xaml.cs`, los primeros contienen la pantalla visual utilizando XML y los segundos son los encargados de recoger estos datos:

###### `ClientDetailPage.xaml`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="ClientManagerApp.ClientDetailPage"
             Title="{Binding Title}">
    <StackLayout Spacing="20" Padding="15">
        <Image x:Name="DetailPageImage"></Image>
        <Label Text="{Binding Name}" FontSize="Large" FontAttributes="Bold" HorizontalOptions="Center"/>
        <Label Text="{Binding Email}" FontSize="Medium" FontAttributes="Italic" HorizontalOptions="Center"/>
        <Grid Padding="10">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto" />
            </Grid.RowDefinitions>

            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*" />
                <ColumnDefinition Width="*" />
            </Grid.ColumnDefinitions>

            <StackLayout Grid.RowSpan="2" Grid.Column="0" Orientation="Horizontal"
                         HorizontalOptions="End">
                <Label Text="{Binding City}" FontSize="Medium"/>
                <Label Text="{Binding Country}" FontSize="Medium"/>
            </StackLayout>
        </Grid>
    </StackLayout>
</ContentPage>
```

###### `ClientDetailPage.xaml.cs`:

```c#
public partial class ClientDetailPage : ContentPage
    {
        Client _client;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ClientDetailPage()
        {
            InitializeComponent();

            BindingContext = _client;
        }

        public ClientDetailPage(Client client)
        {
            InitializeComponent();

            this._client = client;

            //DetailPageImage.Source = ImageSource.FromUri(new Uri(client.Image));

            //DetailPageImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromInvariantString(client.Image);

            //DetailPageImage.Source.GetValue(UriImageSource.UriProperty);

            BindingContext = _client;
        }
    }
```

###### `ClientsPage.xaml`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="ClientManagerApp.ClientsPage"
              Title="{Binding Title}"
             x:Name="BrowseItemsPage">
    <ContentPage.ToolbarItems>
        <ToolbarItem Text="Añadir" Clicked="AddClient_Clicked" />
    </ContentPage.ToolbarItems>

    <ContentPage.Content>
        <StackLayout>
            <ListView x:Name="ItemsListView" 
                ItemsSource="{Binding Items}"
                VerticalOptions="FillAndExpand"
                 HasUnevenRows="true"
                 RefreshCommand="{Binding LoadItemsCommand}"
                 IsPullToRefreshEnabled="true"
                 IsRefreshing="{Binding IsBusy, Mode=OneWay}"
                 CachingStrategy="RecycleElement"
                 ItemSelected="OnItemSelected">

                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Grid Padding="10">
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto" />
                                    <RowDefinition Height="*" />
                                </Grid.RowDefinitions>

                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="Auto" />
                                    <ColumnDefinition Width="*" />
                                </Grid.ColumnDefinitions>

                                <Label Text="{Binding Name}" 
                                       Grid.Row="0" Grid.Column="0"
                                       LineBreakMode="NoWrap" 
                                       Style="{DynamicResource ListItemTextStyle}" 
                                       FontSize="16" />
                                <Label Text="{Binding City}" 
                                       Grid.Row="1" Grid.Column="0"
                                       LineBreakMode="NoWrap"
                                       Style="{DynamicResource ListItemDetailTextStyle}"
                                       FontSize="13" />

                                <StackLayout Grid.RowSpan="2"
                                             Grid.Column="1"
                                             Orientation="Horizontal"
                                             HorizontalOptions="End">
                                    <Button Text="Editar"
                                            CommandParameter="{Binding ClientId}"
                                            BackgroundColor="{DynamicResource PrimaryDark}"
                                            TextColor="White"
                                            Clicked="EditButton_OnClicked"
                                    ></Button>
                                    <Button Text="Eliminar"
                                            CommandParameter="{Binding ClientId}"
                                            Clicked="DeleteButton_OnClicked"
                                            BackgroundColor="{DynamicResource PrimaryDark}"
                                            TextColor="White"
                                    ></Button>
                                </StackLayout>
                            </Grid>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

###### `ClientsPage.xaml.cs`:

```c#
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
```

###### `EditClientPage.xaml`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             Title="Editar Cliente"
             x:Class="ClientManagerApp.Views.EditClientPage">
    <ContentPage.ToolbarItems>
        <ToolbarItem Text="Guardar" Clicked="Save_Clicked" />
    </ContentPage.ToolbarItems>
    <ContentPage.Content>
        <StackLayout Spacing="20" Padding="15">
            <Label Text="{Binding ClientId}" x:Name="editClientId" IsVisible="False"></Label>
            <Label Text="Name" FontSize="Medium" />
            <Entry Text="{Binding Name}" x:Name="editName" FontSize="Small" />
            <Label Text="Email" FontSize="Medium" />
            <Editor Text="{Binding Email}" x:Name="editEmail" FontSize="Small" Margin="0" />
            <Label Text="City" FontSize="Medium" />
            <Editor Text="{Binding City}" x:Name="editCity" FontSize="Small" Margin="0" />
            <Label Text="Country" FontSize="Medium" />
            <Editor Text="{Binding Country}" x:Name="editCountry" FontSize="Small" Margin="0" />
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

###### `EditClientPage.xaml.cs`:

```c#
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
```

###### `InformationPage.cs`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="ClientManagerApp.InformationPage"
             xmlns:vm="clr-namespace:ClientManagerApp;"
             Title="{Binding Title}">
    <ContentPage.BindingContext>
        <vm:InformationViewModel />
    </ContentPage.BindingContext>
    <Grid VerticalOptions="FillAndExpand">
        <StackLayout Orientation="Vertical" Padding="16,40,16,40" Spacing="10">
            <Label FontSize="22">
                <Label.FormattedText>
                    <FormattedString>
                        <FormattedString.Spans>
                            <Span Text="ClientManagerApp" FontAttributes="Bold" FontSize="22" />
                            <Span Text=" " />
                            <Span Text="1.0" ForegroundColor="{StaticResource LightTextColor}" />
                        </FormattedString.Spans>
                    </FormattedString>
                </Label.FormattedText>
            </Label>
            <Label>
                <Label.FormattedText>
                    <FormattedString>
                        <FormattedString.Spans>
                            <Span Text="Aplicacion para probar Xamarin" />
                        </FormattedString.Spans>
                    </FormattedString>
                </Label.FormattedText>
            </Label>
            <Label>
                <Label.FormattedText>
                    <FormattedString>
                        <FormattedString.Spans>
                            <Span Text="Aqui se puede poner lo que querais" FontAttributes="Bold" />
                        </FormattedString.Spans>
                    </FormattedString>
                </Label.FormattedText>
            </Label>
            <Button Margin="0,10,0,0" Text="Ir a Github" Command="{Binding OpenWebCommand}" BackgroundColor="{StaticResource Primary}" TextColor="White" VerticalOptions="End" />
        </StackLayout>
    </Grid>
</ContentPage>
```

###### `InformationPage.xaml.cs`:

```c#
public partial class InformationPage : ContentPage
    {
        public InformationPage()
        {
            InitializeComponent();
        }
    }
```

###### `MainPage.cs`: Página inicial sobre la que se montan el resto de vistas.

```c#
public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage = null;
            Page aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    
                    itemsPage = new NavigationPage(new ClientsPage())
                    {
                        Title = "Clientes"
                    };
                    aboutPage = new NavigationPage(new InformationPage())
                    {
                        Title = "Informacion"
                    };
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    itemsPage = new ClientsPage()
                    {
                        Title = "Clientes"
                    };
                    aboutPage = new InformationPage()
                    {
                        Title = "Informacion"
                    };
                    break;
            }

            Children.Add(itemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
```

###### `NewClientPage.xaml`:

```c#
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="ClientManagerApp.NewClientPage"
		Title="Nuevo Cliente">
	<ContentPage.ToolbarItems>
		<ToolbarItem Text="Guardar" Clicked="Save_Clicked" />
	</ContentPage.ToolbarItems>
	<ContentPage.Content>
		<StackLayout Spacing="20" Padding="15">
			<Label Text="Name" FontSize="Medium" />
            <Entry Text="{Binding Item.Name}" x:Name="newName" FontSize="Small" />
            <Label Text="Email" FontSize="Medium" />
            <Editor Text="{Binding Item.Email}" x:Name="newEmail" FontSize="Small" Margin="0" />
            <Label Text="City" FontSize="Medium" />
            <Editor Text="{Binding Item.City}" x:Name="newCity" FontSize="Small" Margin="0" />
            <Label Text="Country" FontSize="Medium" />
            <Editor Text="{Binding Item.Country}" x:Name="newCountry" FontSize="Small" Margin="0" />
        </StackLayout>
	</ContentPage.Content>
</ContentPage>

```

###### `NewClientPage.xaml.cs`:

```c#
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
```

#### Carpeta raíz: Contiene el archivo `App.xaml`y `App.xaml.cs`, que son los que llama cada móvil al arrancar, en nuestro caso los hemos utilizado como diccionario de recursos: colores.

##### `App.xaml`:

```c#
<?xml version="1.0" encoding="utf-8"?>
<Application xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="ClientManagerApp.App">
  <Application.Resources>
        <ResourceDictionary>
            <Color x:Key="Primary">#208B7D</Color>
            <Color x:Key="PrimaryDark">#145E55</Color>
            <Color x:Key="Accent">#96d1ff</Color>
            <Color x:Key="LightBackgroundColor">#FAFAFA</Color>
            <Color x:Key="DarkBackgroundColor">#C0C0C0</Color>
            <Color x:Key="MediumGrayTextColor">#4d4d4d</Color>
            <Color x:Key="LightTextColor">#999999</Color>

            <Style TargetType="NavigationPage">
                <Setter Property="BarBackgroundColor" Value="{StaticResource Primary}" />
                <Setter Property="BarTextColor" Value="White" />
            </Style>
        </ResourceDictionary>
    </Application.Resources>
</Application>

```

##### `App.xaml.cs`

```c#
public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }
    }
```