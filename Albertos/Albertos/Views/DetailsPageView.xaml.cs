using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Albertos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPageView : ContentPage
    {
        Button selectedSizeBtn = new Button();
        Style unselectedStyle = (Style)Application.Current.Resources["SizeStyle"];
        Style selectedStyle = (Style)Application.Current.Resources["SelectedSizeStyle"];

        
        public DetailsPageView()
        {
            InitializeComponent();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.White;
            navigationPage.BarTextColor = Color.FromHex("#000000");

            selectedSizeBtn = BtnSmall;
            selectedSizeBtn.Style = selectedStyle;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            if(btn != selectedSizeBtn)
            {
                switch (btn.Text)
                {
                    case "S":
                        _ = TwistImage(1, 0);
                        break;
                    case "M":
                        _ = TwistImage(1.2, 180);
                        break;
                    case "L":
                        _ = TwistImage(1.4, 360);
                        break;
                }

                selectedSizeBtn.Style = unselectedStyle;
                selectedSizeBtn = btn;
                selectedSizeBtn.Style = selectedStyle;
            }
        }

        private async Task TwistImage(double scale, int degree)
        {
            await Task.WhenAll(
                PizzaImage.RotateTo(degree, 150, Easing.SinInOut),
                PizzaImage.ScaleTo(scale, 150, Easing.SinInOut)
            );
        }
    }
}