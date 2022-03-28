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
        Button n_btn, l_btn, b_btn, rules_btn;
        public MainPage()
        {
            InitializeComponent();
            n_btn = new Button
            {
                Text = "Uus mänd pildidega",
                BackgroundColor = Color.Bisque,
                TextColor = Color.Black
            };
            n_btn.Clicked += Start_Page;

            l_btn = new Button
            {
                Text = "Uus mänd leibliga",
                BackgroundColor = Color.LightSalmon,
                TextColor = Color.Black
            };
            l_btn.Clicked += Start_Page;

            b_btn = new Button
            {
                Text = "Uus mäng nuppuga",
                BackgroundColor = Color.LightYellow,
                TextColor = Color.Black
            };
            b_btn.Clicked += Start_Page;

            rules_btn = new Button
            {
                Text = "Rules",
                BackgroundColor = Color.BlanchedAlmond,
                TextColor = Color.Black
            };
            rules_btn.Clicked += Start_Page;

            StackLayout st = new StackLayout
            {
                Children = { n_btn, l_btn, b_btn, rules_btn }
            };
            st.BackgroundColor = Color.LightYellow;
            Content = st;
        }

        private async void Start_Page(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(sender == n_btn)
            {
                await Navigation.PushAsync(new Game2_Page());
            }
            else if (sender == l_btn)
            {
                await Navigation.PushAsync(new Game_Page());
            }
            else if(sender== b_btn)
            {
                await Navigation.PushAsync(new Game3_Page());
            }
            else if(sender == rules_btn)
            {
                await Navigation.PushAsync(new Rules_Page());
            }
        }
    }
}
