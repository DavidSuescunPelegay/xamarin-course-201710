using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace ClientManagerApp
{
    public class InformationViewModel : BaseViewModel
    {
        public InformationViewModel()
        {
            Title = "Informacion";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/DavidSuescunPelegay/xamarin_course_201710")));
        }

        public ICommand OpenWebCommand { get; }
    }
}