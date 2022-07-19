using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LearnWithLaerdal.ViewModels
{
    public class InfoPageViewModel : BaseViewModel
    {
        public InfoPageViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://laerdal.com/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}