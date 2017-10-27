using System;

using Xamarin.Forms;

namespace ClientManagerApp
{
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
}
