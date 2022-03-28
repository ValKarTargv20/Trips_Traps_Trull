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
    public partial class Game3_Page : ContentPage
    {
        Frame frame;
        Grid grid;
        Button btn;
        Label lbl;
        string fir;
        int taps;
        public Game3_Page()
        {
            InitializeComponent();
            BackgroundColor = Color.LightYellow;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("x või o?", "Tühistamine", null, "x", "o");
            if (action == "x")
            {
                fir="x";
                Grid_Frame();
            }
            else if (action == "o")
            {
                fir="o";
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
                    btn = new Button();
                    btn.Text = "";
                    btn.BackgroundColor = Color.Yellow;
                    grid.Children.Add(btn, c, r);
                    btn.Clicked += Tap_Tapped;
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
            lbl = new Label
            {
                Text = "Esimene on - " + fir + ". Hod nomer: " + taps,
                TextColor = Color.Black,
                VerticalOptions=LayoutOptions.CenterAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = { frame, lbl }
            };
            Content = st;
        }
        
        private void Tap_Tapped(object sender, EventArgs e)
        {
            taps++;
            var btnsender = (Button)sender;
            var r = Grid.GetRow(btnsender);
            var c = Grid.GetColumn(btnsender);
            if (taps % 2 ==0 && btnsender.BackgroundColor != Color.Lime)
            {
                if (fir == "x")
                {
                    btnsender.Text = "o";
                    btnsender.TextColor = Color.Black;
                    btnsender.BackgroundColor = Color.Lime;
                }
                else if (fir == "o")
                {
                    btnsender.Text = "x";
                    btnsender.TextColor = Color.Black;
                    btnsender.BackgroundColor = Color.Lime;
                }
                    
            }
            else if (taps%2!=0 && btnsender.BackgroundColor != Color.Lime)
            {
                if(fir == "o")
                {
                    btnsender.Text = "o";
                    btnsender.TextColor = Color.Black;
                    btnsender.BackgroundColor = Color.Lime;
                }
                else if (fir == "x")
                {
                    btnsender.Text = "x";
                    btnsender.TextColor = Color.Black;
                    btnsender.BackgroundColor = Color.Lime;
                }
                    
            }
            else
            {
                taps--;
            }
            
        }
    }
}