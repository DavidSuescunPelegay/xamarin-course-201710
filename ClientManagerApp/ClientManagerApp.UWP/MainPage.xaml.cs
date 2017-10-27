namespace ClientManagerApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new ClientManagerApp.App());
        }
    }
}