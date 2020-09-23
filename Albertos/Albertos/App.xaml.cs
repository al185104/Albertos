using Albertos.Services.Navigation;
using Albertos.Services.Product;
using Albertos.ViewModels.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Albertos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected async override void OnStart()
        {
            base.OnStart();
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private Task InitNavigation()
        {
            var productService = ViewModelLocator.Resolve<IProductService>();
            productService.GetAllProductsAsync();

            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }
    }
}
