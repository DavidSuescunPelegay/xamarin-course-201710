# Troubleshooting

- In case of error: **Couldn't connect to debugger**
  - Disable "Use fast deployment (debug mode only)" in Android project -> Properties -> Android options -> Packaging
  - Enable "Migrate to a physical computer with a different processor version" in Hyper-V manager go to VM -> Settings -> Processor -> Compatibility
  - [StackOverflow](https://stackoverflow.com/questions/32589438/xamarin-android-visual-studio-2015-could-not-connect-to-the-debugger)
- In case of error: **HypervisorNotRunning (13)**
  - Run as admin
  - Start cmd as admin and type --> bcdedit /set hypervisorlaunchtype auto
  - [StackOverflow](https://stackoverflow.com/questions/42917321/visual-studio-android-emulator-not-installing-profiles)
- In case of error: **PushAsync is not supported globally on Android, please use a NavigationPage - Xamarin.Forms**
  - MainPage = new NavigationPage(new ClientsListView());
  - [StackOverflow](https://stackoverflow.com/questions/24621814/pushasync-is-not-supported-globally-on-android-please-use-a-navigationpage-xa)
