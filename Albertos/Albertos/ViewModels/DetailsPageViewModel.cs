using Albertos.Models;
using Albertos.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Albertos.ViewModels
{
    class DetailsPageViewModel : ViewModelBase
    {
        #region Properties
        private ProductModel pizza;

        public ProductModel Pizza
        {
            get { return pizza; }
            set { pizza = value; RaisePropertyChanged(() => Pizza); }
        } 
        #endregion

        #region Constructors
        public DetailsPageViewModel()
        {

        }
        #endregion

        public override Task InitializeAsync(object navigationData)
        {
            if(navigationData != null && navigationData is ProductModel)
            {
                Pizza = navigationData as ProductModel;
            }

            return base.InitializeAsync(navigationData);
        }
    }
}
