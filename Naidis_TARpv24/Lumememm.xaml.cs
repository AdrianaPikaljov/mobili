using Microsoft.Maui.Layouts;

namespace Naidis_TARpv24;

public partial class Lumememm : ContentPage
{
    AbsoluteLayout abs;
    VerticalStackLayout vst;
    Label pealdis, tegevusLbl, heledusLbl, kiirusLbl;
    Picker picker;
    Button kaivitaNupp;
    Slider heledusSlider;
    Stepper kiirusStepper;

    Frame amber, pea, keha;
    BoxView vasakSilm, paremSilm, nina, nupp1, nupp2, nupp3;

    Random rnd = new Random();
    uint kiirus = 1000;

    public Lumememm()
    {
        BackgroundColor = Colors.LightBlue;

        pealdis = new Label
        {
            Text = "Lumememm",
            FontSize = 40,
            FontFamily = "Luffio",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
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
        AbsoluteLayout.SetLayoutFlags(amber, AbsoluteLayoutFlags.None);
        abs.Add(amber);

        pea = new Frame
        {
            BackgroundColor = Colors.White,
            WidthRequest = 80,
            HeightRequest = 80,
            CornerRadius = 40,
            Padding = 0,
            HasShadow = true
        };
        AbsoluteLayout.SetLayoutBounds(pea, new Rect(160, 50, 80, 80));
        AbsoluteLayout.SetLayoutFlags(pea, AbsoluteLayoutFlags.None);
        abs.Add(pea);

        keha = new Frame
        {
            BackgroundColor = Colors.White,
            WidthRequest = 120,
            HeightRequest = 120,
            CornerRadius = 60,
            Padding = 0,
            HasShadow = true
        };
        AbsoluteLayout.SetLayoutBounds(keha, new Rect(140, 135, 120, 120));
        AbsoluteLayout.SetLayoutFlags(keha, AbsoluteLayoutFlags.None);
        abs.Add(keha);

        vasakSilm = new BoxView
        {
            Color = Colors.Black,
            WidthRequest = 8,
            HeightRequest = 8,
            CornerRadius = 4
        };
        AbsoluteLayout.SetLayoutBounds(vasakSilm, new Rect(182, 80, 8, 8));
        AbsoluteLayout.SetLayoutFlags(vasakSilm, AbsoluteLayoutFlags.None);
        abs.Add(vasakSilm);

        paremSilm = new BoxView
        {
            Color = Colors.Black,
            WidthRequest = 8,
            HeightRequest = 8,
            CornerRadius = 4
        };
        AbsoluteLayout.SetLayoutBounds(paremSilm, new Rect(210, 80, 8, 8));
        AbsoluteLayout.SetLayoutFlags(paremSilm, AbsoluteLayoutFlags.None);
        abs.Add(paremSilm);

        nina = new BoxView
        {
            Color = Colors.Orange,
            WidthRequest = 14,
            HeightRequest = 6,
            CornerRadius = 2
        };
        AbsoluteLayout.SetLayoutBounds(nina, new Rect(194, 97, 14, 6));
        AbsoluteLayout.SetLayoutFlags(nina, AbsoluteLayoutFlags.None);
        abs.Add(nina);

        nupp1 = new BoxView
        {
            Color = Colors.Black,
            WidthRequest = 10,
            HeightRequest = 10,
            CornerRadius = 5
        };
        AbsoluteLayout.SetLayoutBounds(nupp1, new Rect(195, 165, 10, 10));
        AbsoluteLayout.SetLayoutFlags(nupp1, AbsoluteLayoutFlags.None);
        abs.Add(nupp1);

        nupp2 = new BoxView
        {
            Color = Colors.Black,
            WidthRequest = 10,
            HeightRequest = 10,
            CornerRadius = 5
        };
        AbsoluteLayout.SetLayoutBounds(nupp2, new Rect(195, 195, 10, 10));
        AbsoluteLayout.SetLayoutFlags(nupp2, AbsoluteLayoutFlags.None);
        abs.Add(nupp2);

        nupp3 = new BoxView
        {
            Color = Colors.Black,
            WidthRequest = 10,
            HeightRequest = 10,
            CornerRadius = 5
        };
        AbsoluteLayout.SetLayoutBounds(nupp3, new Rect(195, 225, 10, 10));
        AbsoluteLayout.SetLayoutFlags(nupp3, AbsoluteLayoutFlags.None);
        abs.Add(nupp3);

        picker = new Picker
        {
            Title = "Vali tegevus"
        };
        picker.Items.Add("Peida lumememm");
        picker.Items.Add("Näita lumememm");
        picker.Items.Add("Muuda värvi");
        picker.Items.Add("Sulata");
        picker.Items.Add("Tantsi");

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
            FontFamily = "Luffio",
            FontSize = 28,
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10
        };
        kaivitaNupp.Clicked += KaivitaNupp_Clicked;

        heledusLbl = new Label
        {
            Text = "Läbipaistvus: 1.0",
            FontSize = 22
        };

        heledusSlider = new Slider
        {
            Minimum = 0,
            Maximum = 1,
            Value = 1
        };
        heledusSlider.ValueChanged += HeledusSlider_ValueChanged;

        kiirusLbl = new Label
        {
            Text = "Kiirus: 1000 ms",
            FontSize = 22
        };

        kiirusStepper = new Stepper
        {
            Minimum = 200,
            Maximum = 3000,
            Increment = 200,
            Value = 1000
        };
        kiirusStepper.ValueChanged += KiirusStepper_ValueChanged;

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
        vst.Add(heledusLbl);
        vst.Add(heledusSlider);
        vst.Add(kiirusLbl);
        vst.Add(kiirusStepper);

        Content = new ScrollView { Content = vst };
    }

    private void KiirusStepper_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        kiirus = (uint)e.NewValue;
        kiirusLbl.Text = "Kiirus: " + kiirus + " ms";
    }

    private void HeledusSlider_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;

        amber.Opacity = value;
        pea.Opacity = value;
        keha.Opacity = value;
        vasakSilm.Opacity = value;
        paremSilm.Opacity = value;
        nina.Opacity = value;
        nupp1.Opacity = value;
        nupp2.Opacity = value;
        nupp3.Opacity = value;

        heledusLbl.Text = "Läbipaistvus: " + value.ToString("F1");
    }

    private async void KaivitaNupp_Clicked(object? sender, EventArgs e)
    {
        if (picker.SelectedIndex == -1)
        {
            await DisplayAlert("Hoiatus", "Palun vali tegevus!", "OK");
            return;
        }

        string tegevus = picker.Items[picker.SelectedIndex];
        tegevusLbl.Text = "Valitud tegevus: " + tegevus;

        if (tegevus == "Peida lumememm")
        {
            PeidaLumememm();
        }
        else if (tegevus == "Näita lumememm")
        {
            NaitaLumememm();
        }
        else if (tegevus == "Muuda värvi")
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
    }

    private void PeidaLumememm()
    {
        abs.IsVisible = false;
        tegevusLbl.Text = "Lumememm on peidetud";
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

        abs.TranslationX = 0;

        tegevusLbl.Text = "Lumememm on nähtav";
    }

    private async Task MuudaVarvi()
    {
        bool vastus = await DisplayAlert("Kinnitus", "Kas soovid värvi muuta?", "Jah", "Ei");

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
            tegevusLbl.Text = "Värvi ei muudetud";
        }
    }

    private async Task Sulata()
    {
        abs.IsVisible = true;

        await Task.WhenAll(
            amber.FadeTo(0.2, kiirus),
            pea.FadeTo(0.2, kiirus),
            keha.FadeTo(0.2, kiirus),
            vasakSilm.FadeTo(0.2, kiirus),
            paremSilm.FadeTo(0.2, kiirus),
            nina.FadeTo(0.2, kiirus),
            nupp1.FadeTo(0.2, kiirus),
            nupp2.FadeTo(0.2, kiirus),
            nupp3.FadeTo(0.2, kiirus),

            amber.ScaleTo(0.7, kiirus),
            pea.ScaleTo(0.7, kiirus),
            keha.ScaleTo(0.7, kiirus)
        );

        tegevusLbl.Text = "Lumememm sulas";
    }

    private async Task Tantsi()
    {
        abs.IsVisible = true;
        tegevusLbl.Text = "Lumememm tantsib";

        for (int i = 0; i < 3; i++)
        {
            await abs.TranslateTo(-30, 0, kiirus / 2);
            await abs.TranslateTo(30, 0, kiirus / 2);
        }

        await abs.TranslateTo(0, 0, kiirus / 2);
        tegevusLbl.Text = "Tants tehtud";
    }
}