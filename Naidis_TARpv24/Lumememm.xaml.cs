using Microsoft.Maui.Layouts;

namespace Naidis_TARpv24;

public partial class Lumememm : ContentPage
{
    AbsoluteLayout abs;
    VerticalStackLayout vst;
    Label pealdis, tegevusLbl;
    Picker picker;
    Button kaivitaNupp;

    Frame amber, pea, keha;
    BoxView vasakSilm, paremSilm, nina, nupp1, nupp2, nupp3;

    Random rnd = new Random();

    public Lumememm()
    {
        BackgroundColor = Colors.LightBlue;

        pealdis = new Label
        {
            Text = "Lumememm",
            FontSize = 40,
            HorizontalOptions = LayoutOptions.Center,
            TextColor = Colors.Black
        };

        abs = new AbsoluteLayout
        {
            HeightRequest = 350,
            WidthRequest = 400,
            BackgroundColor = Colors.AliceBlue
        };

        amber = new Frame
        {
            BackgroundColor = Colors.Brown,
            WidthRequest = 70,
            HeightRequest = 30,
            CornerRadius = 5,
            Padding = 0,
            HasShadow = false
        };
        AbsoluteLayout.SetLayoutBounds(amber, new Rect(165, 20, 70, 30));
        abs.Add(amber);

        pea = new Frame
        {
            BackgroundColor = Colors.White,
            WidthRequest = 80,
            HeightRequest = 80,
            CornerRadius = 40,
            Padding = 0
        };
        AbsoluteLayout.SetLayoutBounds(pea, new Rect(160, 50, 80, 80));
        abs.Add(pea);

        keha = new Frame
        {
            BackgroundColor = Colors.White,
            WidthRequest = 120,
            HeightRequest = 120,
            CornerRadius = 60,
            Padding = 0
        };
        AbsoluteLayout.SetLayoutBounds(keha, new Rect(140, 135, 120, 120));
        abs.Add(keha);

        vasakSilm = new BoxView
        {
            Color = Colors.Black,
            WidthRequest = 8,
            HeightRequest = 8,
            CornerRadius = 4
        };
        AbsoluteLayout.SetLayoutBounds(vasakSilm, new Rect(182, 80, 8, 8));
        abs.Add(vasakSilm);

        paremSilm = new BoxView
        {
            Color = Colors.Black,
            WidthRequest = 8,
            HeightRequest = 8,
            CornerRadius = 4
        };
        AbsoluteLayout.SetLayoutBounds(paremSilm, new Rect(210, 80, 8, 8));
        abs.Add(paremSilm);

        nina = new BoxView
        {
            Color = Colors.Orange,
            WidthRequest = 14,
            HeightRequest = 6,
            CornerRadius = 2
        };
        AbsoluteLayout.SetLayoutBounds(nina, new Rect(194, 97, 14, 6));
        abs.Add(nina);

        nupp1 = new BoxView
        {
            Color = Colors.Black,
            WidthRequest = 10,
            HeightRequest = 10,
            CornerRadius = 5
        };
        AbsoluteLayout.SetLayoutBounds(nupp1, new Rect(195, 165, 10, 10));
        abs.Add(nupp1);

        nupp2 = new BoxView
        {
            Color = Colors.Black,
            WidthRequest = 10,
            HeightRequest = 10,
            CornerRadius = 5
        };
        AbsoluteLayout.SetLayoutBounds(nupp2, new Rect(195, 195, 10, 10));
        abs.Add(nupp2);

        nupp3 = new BoxView
        {
            Color = Colors.Black,
            WidthRequest = 10,
            HeightRequest = 10,
            CornerRadius = 5
        };
        AbsoluteLayout.SetLayoutBounds(nupp3, new Rect(195, 225, 10, 10));
        abs.Add(nupp3);

        picker = new Picker
        {
            Title = "Vali tegevus"
        };

        picker.Items.Add("Peida lumememm");
        picker.Items.Add("Näita lumememm");
        picker.Items.Add("Muuda lumememmi värvi");
        picker.Items.Add("Sulata");
        picker.Items.Add("Tantsi");
        picker.Items.Add("Muuda ämbri värvi");

        tegevusLbl = new Label
        {
            Text = "Valitud tegevus kuvatakse siia",
            FontSize = 22,
            HorizontalOptions = LayoutOptions.Center,
            TextColor = Colors.DarkBlue
        };

        picker.SelectedIndexChanged += (sender, e) =>
        {
            if (picker.SelectedIndex >= 0)
            {
                tegevusLbl.Text = "Valitud tegevus: " + picker.Items[picker.SelectedIndex];
            }
        };

        kaivitaNupp = new Button
        {
            Text = "Käivita tegevus",
            FontSize = 28,
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10
        };

        kaivitaNupp.Clicked += KaivitaNupp_Clicked;

        vst = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15
        };

        vst.Add(pealdis);
        vst.Add(abs);
        vst.Add(picker);
        vst.Add(kaivitaNupp);
        vst.Add(tegevusLbl);

        Content = new ScrollView { Content = vst };
    }

    private async void KaivitaNupp_Clicked(object sender, EventArgs e)
    {
        if (picker.SelectedIndex == -1)
        {
            await DisplayAlert("Hoiatus", "Palun vali tegevus!", "OK");
            return;
        }

        string tegevus = picker.Items[picker.SelectedIndex];

        if (tegevus == "Peida lumememm")
        {
            abs.IsVisible = false;
            tegevusLbl.Text = "Lumememm on peidetud";
        }
        else if (tegevus == "Näita lumememm")
        {
            NaitaLumememm();
        }
        else if (tegevus == "Muuda lumememmi värvi")
        {
            await MuudaVarvi();
        }
        else if (tegevus == "Sulata")
        {
            await Sulata();
        }
        else if (tegevus == "Tantsi")
        {
            await Tantsi();
        }
        else if (tegevus == "Muuda ämbri värvi")
        {
            await MuudaAmbriVarvi();
        }
    }

    private void NaitaLumememm()
    {
        abs.IsVisible = true;

        amber.Opacity = 1;
        pea.Opacity = 1;
        keha.Opacity = 1;
        vasakSilm.Opacity = 1;
        paremSilm.Opacity = 1;
        nina.Opacity = 1;
        nupp1.Opacity = 1;
        nupp2.Opacity = 1;
        nupp3.Opacity = 1;

        amber.Scale = 1;
        pea.Scale = 1;
        keha.Scale = 1;
        vasakSilm.Scale = 1;
        paremSilm.Scale = 1;
        nina.Scale = 1;
        nupp1.Scale = 1;
        nupp2.Scale = 1;
        nupp3.Scale = 1;

        abs.TranslationX = 0;

        pea.BackgroundColor = Colors.White;
        keha.BackgroundColor = Colors.White;
        amber.BackgroundColor = Colors.Brown;
        vasakSilm.Color = Colors.Black;
        paremSilm.Color = Colors.Black;
        nina.Color = Colors.Orange;
        nupp1.Color = Colors.Black;
        nupp2.Color = Colors.Black;
        nupp3.Color = Colors.Black;

        tegevusLbl.Text = "Lumememm on taastatud";
    }

    private async Task MuudaVarvi()
    {
        bool vastus = await DisplayAlert("Kinnitus", "Kas soovid lumememme värvi muuta?", "Jah", "Ei");

        if (vastus)
        {
            Color uusVarv = Color.FromRgb(
                rnd.Next(50, 256),
                rnd.Next(50, 256),
                rnd.Next(50, 256));

            pea.BackgroundColor = uusVarv;
            keha.BackgroundColor = uusVarv;

            tegevusLbl.Text = "Lumememme värv muudeti";
        }
        else
        {
            tegevusLbl.Text = "Lumememme värvi ei muudetud";
        }
    }

    private async Task MuudaAmbriVarvi()
    {
        bool vastus = await DisplayAlert("Kinnitus", "Kas soovid ämbri värvi muuta?", "Jah", "Ei");

        if (vastus)
        {
            Color uusVarv = Color.FromRgb(
                rnd.Next(50, 256),
                rnd.Next(50, 256),
                rnd.Next(50, 256));

            amber.BackgroundColor = uusVarv;

            tegevusLbl.Text = "Ämbri värv muudeti";
        }
        else
        {
            tegevusLbl.Text = "Ämbri värvi ei muudetud";
        }
    }

    private async Task Sulata()
    {
        abs.IsVisible = true;

        await Task.WhenAll(
            amber.FadeTo(0.2, 1000),
            pea.FadeTo(0.2, 1000),
            keha.FadeTo(0.2, 1000),
            vasakSilm.FadeTo(0.2, 1000),
            paremSilm.FadeTo(0.2, 1000),
            nina.FadeTo(0.2, 1000),
            nupp1.FadeTo(0.2, 1000),
            nupp2.FadeTo(0.2, 1000),
            nupp3.FadeTo(0.2, 1000),

            amber.ScaleTo(0.7, 1000),
            pea.ScaleTo(0.7, 1000),
            keha.ScaleTo(0.7, 1000)
        );

        tegevusLbl.Text = "Lumememm sulas";
    }

    private async Task Tantsi()
    {
        abs.IsVisible = true;
        tegevusLbl.Text = "Lumememm tantsib";

        for (int i = 0; i < 3; i++)
        {
            await abs.TranslateTo(-30, 0, 500);
            await abs.TranslateTo(30, 0, 500);
        }

        await abs.TranslateTo(0, 0, 500);

        tegevusLbl.Text = "Tants tehtud";
    }
}