using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnWithLaerdal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }


        async void MainB_Clicked(object sender, EventArgs e)
        {
            await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            
            await Navigation.PushAsync(new StartGame()); 
        }

    }

}