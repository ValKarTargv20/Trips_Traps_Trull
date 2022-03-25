using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Trips_Traps_Trull
{
    public partial class MainPage : ContentPage
    {
        Button n_btn, rules_btn;
        public MainPage()
        {
            InitializeComponent();
            n_btn = new Button
            {
                Text = "New Game",
                BackgroundColor = Color.Bisque,
                TextColor = Color.Black
            };
            n_btn.Clicked += Start_Page;

            rules_btn = new Button
            {
                Text = "Rules",
                BackgroundColor = Color.BlanchedAlmond,
                TextColor = Color.Black
            };
            rules_btn.Clicked += Start_Page;

            StackLayout st = new StackLayout
            {
                Children = { n_btn, rules_btn }
            };
            st.BackgroundColor = Color.LightYellow;
            Content = st;
        }

        private async void Start_Page(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(sender == n_btn)
            {
                await Navigation.PushAsync(new Game_Page());
            }
            else if(sender == rules_btn)
            {
                await Navigation.PushAsync(new Rules_Page());
            }
        }
    }
}
