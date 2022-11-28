using HarryPotter_App.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HarryPotter_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }
    }
}