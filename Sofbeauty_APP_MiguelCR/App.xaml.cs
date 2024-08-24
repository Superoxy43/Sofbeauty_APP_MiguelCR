using Sofbeauty_APP_MiguelCR.Views;

namespace Sofbeauty_APP_MiguelCR
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
