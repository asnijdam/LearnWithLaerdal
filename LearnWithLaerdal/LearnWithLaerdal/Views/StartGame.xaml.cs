using LearnWithLaerdal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnWithLaerdal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartGame : ContentPage
    {
        StartGameViewModel vm;
        readonly Animation rotation; 
        public StartGame()
        {
            InitializeComponent();
            rotation = new Animation(v => LabelLoad.Rotation =v, 0,360, Easing.Linear);
            vm = (StartGameViewModel)BindingContext;
            vm.PropertyChanged += Vm_PropertyChanged;
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(vm.IsBusy))
            {
                if (vm.IsBusy)
                {
                    //animate
                    rotation.Commit(this, "rotate", 16, 1000, Easing.Linear,
                        (v, c) => LabelLoad.Rotation = 0,
                        () => true);
                }   
                else
                {
                    //stop

                    this.AbortAnimation("rotate");
                }
            }
        }
    }
}

//Fade in fade out while bouncing code
/*var a1 = LabelLoad.FadeTo(0, 1000, Easing.Linear);
var a2 = LabelLoad.ScaleTo(2, 1000, Easing.BounceIn);

await Task.WhenAll(a1, a2);

var a3 = LabelLoad.FadeTo(1, 1000, Easing.Linear);
var a4 = LabelLoad.ScaleTo(1, 1000, Easing.BounceOut);

await Task.WhenAll(a1, a2);*/