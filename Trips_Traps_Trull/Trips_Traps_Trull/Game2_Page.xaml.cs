using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trips_Traps_Trull
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game2_Page : ContentPage
    {
        Frame frame;
        Image img;
        Grid grid;
        string fir;

        public Game2_Page()
        {
            InitializeComponent();
            BackgroundColor = Color.LightYellow;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("x või o?", "Tühistamine", null, "x", "o");
            if (action == "x")
            {
                fir = "x";
                Grid_Frame();

            }
            else if (action == "o")
            {
                fir = "o";
                Grid_Frame();
            }

        }

        private void Grid_Frame()
        {
            Grid grid = new Grid();
            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                
            }
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    img = new Image { Source = "tuhi.jpg" };
                    grid.Children.Add(img, c, r);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    img.GestureRecognizers.Add(tap);
                }
            }

            frame = new Frame
            {
                Content = grid,
                BackgroundColor = Color.LightYellow,
                CornerRadius = 10,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = { frame }
            };
            Content = st;
        }
        int taps;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            taps++;
            var imgsender = (Image)sender;
            var r = Grid.GetRow(imgsender);
            var c = Grid.GetColumn(imgsender);
            if (taps % 2 == 0)
            {
                if (fir == "x")
                {
                    imgsender.Source = "O.png";
                }
                else if (fir == "o")
                {
                    imgsender.Source = "x.png";
                }
                
            }
            else if (taps%2!=0)
            {
                if (fir == "o")
                {
                    imgsender.Source = "O.png";

                }
                else if (fir == "x")
                {
                    imgsender.Source ="x.png";

                }
            }
            else
            {
                taps--;
            }
        }
    }
}