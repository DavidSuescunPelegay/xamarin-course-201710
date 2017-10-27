
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClientManagerApp
{
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
}
