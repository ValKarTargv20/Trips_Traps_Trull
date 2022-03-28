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
    public partial class Game_Page : ContentPage
    {
        Frame frame;
        Grid grid;
        BoxView box;
        Label lbl;
        public Game_Page()
        {
            InitializeComponent();
            BackgroundColor = Color.LightYellow;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("x või o?", "Tühistamine", null, "x", "y");
            if (action == "x")
            {
                X_First();
            }
            else if (action == "y")
            {
                Y_First();
            }
        }

        public void Y_First()
        {
            string fir = "x";
            Grid_Frame();
        }

        public void X_First()
        {
            string fir = "y";
            Grid_Frame();
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
                    box = new BoxView { Color = Color.Green};
                    lbl = new Label { Text = "T", TextColor=Color.Black, FontSize=42,HorizontalOptions=LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.Center };
                    grid.Children.Add(box, c, r);
                    grid.Children.Add(lbl, c, r);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    box.GestureRecognizers.Add(tap);
                    //вариант кнопки!
                    //вариант картинки
                }
            }
            /*lbl = new Label
            {
                Text="T",
                HorizontalOptions=LayoutOptions.Center
            };*/

            frame = new Frame
            {
                Content = grid,
                BorderColor = Color.Lime,
                CornerRadius = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions=LayoutOptions.CenterAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = { frame }
            };
            Content = st;
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var box = (BoxView)sender;
            lbl = new Label();
            var r = Grid.GetRow(box); // koordinty klika po setke
            var c = Grid.GetColumn(box);
            box.Color = Color.Yellow;
            lbl.Text = "X";
            Grid.SetRow(lbl,r);
            Grid.SetColumn(lbl, c);
            
        }
    }
}