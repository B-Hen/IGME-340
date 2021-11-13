using CraneClikcer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CraneClikcer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StorePage : ContentPage
    {
        public StorePage()
        {
            InitializeComponent();

            //Timer to check updates
            Device.StartTimer(TimeSpan.FromSeconds(1), () => 
            {
                //check if score needs to be updated
                ((StorePageViewModel)BindingContext).UpdateScore();
                return true;
            });
        }
    }
}