using Albertos.Helpers;
using Albertos.Models;
using Albertos.Services.Navigation;
using Albertos.Services.Product;
using Albertos.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Albertos.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        #region Properties
        private ObservableCollection<ProductModel> pizzas;

        public ObservableCollection<ProductModel> Pizzas
        {
            get { return pizzas; }
            set { pizzas = value; RaisePropertyChanged(() => Pizzas); }
        }
        
        private ObservableCollection<string> options = new ObservableCollection<string> { IconFont.Cake, IconFont.Hamburger, IconFont.Pizza, IconFont.GlassCocktail };

        public ObservableCollection<string> Options
        {
            get { return options; }
            set { options = value; RaisePropertyChanged(() => Options); }
        }

        private ObservableCollection<string> category = new ObservableCollection<string> { "Popular", "Mexican", "Italian", "All" };

        public ObservableCollection<string> Category
        {
            get { return category; }
            set { category = value; RaisePropertyChanged(() => Category); }
        }
        #endregion

        #region Services
        private IProductService _productService;
        private INavigationService _navigationService;
        #endregion

        #region Constructor
        public MainPageViewModel(
            IProductService productService,
            INavigationService navigationService)
        {
            _productService = productService;
            _navigationService = navigationService;
        }
        #endregion

        #region Override
        public override async Task InitializeAsync(object navigationData)
        {
            var AllProducts = await _productService.GetAllProductsAsync();
            Pizzas = new ObservableCollection<ProductModel>(from item in AllProducts.Items where item.Type != null && item.Type.Equals("Canned Goods") orderby item.Name select item);
        }
        #endregion

        #region Commands
        public ICommand ItemSelectedCommand => new Command(async(obj) => await ExecuteItemSelectedCommand(obj));

        private async Task ExecuteItemSelectedCommand(object obj)
        {
            await _navigationService.NavigateToAsync<DetailsPageViewModel>(obj);
        }
        #endregion
    }
}
