using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unidad_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        async void Button_Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());

        }

        async void Button_Register(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());

        }

    }
}