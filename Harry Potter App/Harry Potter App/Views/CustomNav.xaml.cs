using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HarryPotter_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomNav : NavigationPage
    {
        public CustomNav()
        {
            InitializeComponent();
        }

        public CustomNav(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}