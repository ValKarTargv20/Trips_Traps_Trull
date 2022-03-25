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
    public partial class Rules_Page : ContentPage
    {
        Label lbl;
        Button btn;
        public Rules_Page()
        {
            Title = "Rules";
            lbl = new Label
            {
                Text = "Игроки по очереди ставят на свободные клетки поля 3×3 знаки (один всегда крестики, другой всегда нолики). Первый, выстроивший в ряд 3 своих фигуры по вертикали, горизонтали или диагонали, выигрывает. Первый ход делает игрок, ставящий крестики.",
                TextColor = Color.Brown,
                BackgroundColor = Color.BlanchedAlmond,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            

            btn = new Button
            {
                Text = "Back",
                BackgroundColor = Color.BlanchedAlmond,
                TextColor = Color.Brown,
                VerticalOptions = LayoutOptions.End
            };
            btn.Clicked += Btn_Clicked;

            StackLayout st = new StackLayout
            {
                Children = { lbl, btn }
            };
            st.BackgroundColor = Color.LightYellow;
            Content = st;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}