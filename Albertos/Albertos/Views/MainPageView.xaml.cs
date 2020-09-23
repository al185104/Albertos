using SkiaSharp;
using SkiaSharp.Views.Forms;
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
    public partial class MainPageView : ContentPage
    {
        Button selectedCategory = new Button();
        // apply styles to old and new category
        Style unselectedStyle = (Style)Application.Current.Resources["CategoryStyle"];
        Style selectedStyle = (Style)Application.Current.Resources["SelectedCategoryStyle"];


        public MainPageView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            selectedCategory = CatPopular;
            selectedCategory.Style = selectedStyle;
        }

        private void ShowNavBarClicked(object sender, EventArgs e)
        {
            ShowNavButton.FadeTo(0, 150, Easing.SinInOut);
            ShowNavButton.IsVisible = false;
            NavBar.TranslateTo(0, 0, 200);
        }

        private void HideNavBarClicked(object sender, EventArgs e)
        {
            ShowNavButton.FadeTo(1, 150, Easing.SinInOut);
            ShowNavButton.IsVisible = true;
            NavBar.TranslateTo(-52, 0, 200);
        }

        private void CategoryTabClicked(object sender, EventArgs e)
        {
            var newCategory = (Button)sender;

            if(this.selectedCategory != newCategory)
            {
                // hover to the new category
                HoverBar.WidthRequest = newCategory.WidthRequest;
                HoverBar.TranslateTo(newCategory.Bounds.X, 0, 150, Easing.SinInOut);

                // set style
                this.selectedCategory.Style = unselectedStyle;
                newCategory.Style = selectedStyle;

                // update selected category
                this.selectedCategory = newCategory;
            }
        }

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                // define the color for the shadow
                SKColor shadowColor = Color.FromHex("#000000").ToSKColor();

                paint.IsDither = true;
                paint.IsAntialias = true;
                paint.Color = shadowColor;

                // create filter for drop shadow
                paint.ImageFilter = SKImageFilter.CreateDropShadowOnly(
                    dx: 0, dy: 0,
                    sigmaX: 40, sigmaY: 40,
                    color: shadowColor);

                // define where I want to draw the object
                var corner = info.Width / 2;
                var shadowBounds = new SKRect(65, 65, 460, 460);
                canvas.DrawRoundRect(shadowBounds, corner, corner, paint);
            }

        }
    }
}