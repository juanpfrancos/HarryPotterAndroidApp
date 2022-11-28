using Unidad_2.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unidad_2.Views
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