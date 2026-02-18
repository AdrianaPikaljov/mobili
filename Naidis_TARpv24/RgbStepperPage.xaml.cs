using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using System;
using System.Threading.Tasks;

namespace Naidis_TARpv24;

public partial class RgbStepperPage : ContentPage
{
    Label lblTitle, lblInfo;
    Label lblR, lblG, lblB;

    Slider slR, slG, slB;
    Stepper stR, stG, stB;

    // ÜLAL 3 VÄIKSE RUUDU JAOKS
    Frame boxR, boxG, boxB;

    // Ruudu omaduste stepperid
    Label lblSize, lblRadius, lblOpacity;
    Stepper stSize, stRadius, stOpacity;

    Frame colorFrame;
    Button btnRandom;

    AbsoluteLayout abs;

    bool _syncing = false;

    public RgbStepperPage() : this(0) { }

    public RgbStepperPage(int k)
    {
        Title = "RGB liigur";

        lblTitle = new Label
        {
            Text = "RGB mudel",
            FontSize = 20,
            FontAttributes = FontAttributes.Bold,
            HorizontalTextAlignment = TextAlignment.Center,
            TextColor = Colors.HotPink
        };

        lblInfo = new Label
        {
            Text = "R: 0  G: 0  B: 0",
            FontSize = 16,
            HorizontalTextAlignment = TextAlignment.Center
        };

        // Väärtuse tekstid
        lblR = new Label { Text = "R: 0" };
        lblG = new Label { Text = "G: 0" };
        lblB = new Label { Text = "B: 0" };

        // Sliderid
        slR = MakeSlider();
        slG = MakeSlider();
        slB = MakeSlider();

        // Stepperid RGB jaoks
        stR = MakeStepperRGB();
        stG = MakeStepperRGB();
        stB = MakeStepperRGB();

        // ÜLAL 3 VÄIKEST RUUTU (näitab kanaleid eraldi)
        boxR = MakeSmallBox(Color.FromRgb(0, 0, 0));
        boxG = MakeSmallBox(Color.FromRgb(0, 0, 0));
        boxB = MakeSmallBox(Color.FromRgb(0, 0, 0));

        // Suur värviruut
        colorFrame = new Frame
        {
            WidthRequest = 260,
            HeightRequest = 260,
            CornerRadius = 25,
            HasShadow = false,
            BackgroundColor = Color.FromRgb(0, 0, 0)
        };

        // Random nupp
        btnRandom = new Button
        {
            Text = "Juhuslik värv",
            CornerRadius = 12
        };
        btnRandom.Clicked += async (s, e) => await RandomColorAsync();

        // Ruudu omaduste stepperid
        lblSize = new Label { Text = "Suurus: 260" };
        lblRadius = new Label { Text = "Nurgad: 25" };
        lblOpacity = new Label { Text = "Läbipaistvus: 1.0" };

        stSize = new Stepper { Minimum = 120, Maximum = 320, Increment = 10, Value = 260 };
        stRadius = new Stepper { Minimum = 0, Maximum = 80, Increment = 5, Value = 25 };
        stOpacity = new Stepper { Minimum = 0, Maximum = 1, Increment = 0.1, Value = 1 };

        stSize.ValueChanged += (s, e) => UpdatePreview();
        stRadius.ValueChanged += (s, e) => UpdatePreview();
        stOpacity.ValueChanged += (s, e) => UpdatePreview();

        // Eventid RGB
        slR.ValueChanged += OnSliderChanged;
        slG.ValueChanged += OnSliderChanged;
        slB.ValueChanged += OnSliderChanged;

        stR.ValueChanged += OnStepperChanged;
        stG.ValueChanged += OnStepperChanged;
        stB.ValueChanged += OnStepperChanged;

        // Layout
        abs = new AbsoluteLayout();

        abs.Children.Add(lblTitle);
        abs.Children.Add(lblInfo);

        // ÜLAL 3 RUUTU
        abs.Children.Add(boxR);
        abs.Children.Add(boxG);
        abs.Children.Add(boxB);

        abs.Children.Add(lblR);
        abs.Children.Add(lblG);
        abs.Children.Add(lblB);

        abs.Children.Add(slR); abs.Children.Add(stR);
        abs.Children.Add(slG); abs.Children.Add(stG);
        abs.Children.Add(slB); abs.Children.Add(stB);

        abs.Children.Add(lblSize); abs.Children.Add(stSize);
        abs.Children.Add(lblRadius); abs.Children.Add(stRadius);
        abs.Children.Add(lblOpacity); abs.Children.Add(stOpacity);

        abs.Children.Add(btnRandom);
        abs.Children.Add(colorFrame);

        // Paigutus
        AbsoluteLayout.SetLayoutBounds(lblTitle, new Rect(0.5, 15, 200, 30));
        AbsoluteLayout.SetLayoutFlags(lblTitle, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(lblInfo, new Rect(0.5, 45, 280, 25));
        AbsoluteLayout.SetLayoutFlags(lblInfo, AbsoluteLayoutFlags.PositionProportional);

        // 3 ruutu ülal (kõrvuti)
        AbsoluteLayout.SetLayoutBounds(boxR, new Rect(60, 80, 55, 55));
        AbsoluteLayout.SetLayoutBounds(boxG, new Rect(130, 80, 55, 55));
        AbsoluteLayout.SetLayoutBounds(boxB, new Rect(200, 80, 55, 55));

        // R/G/B tekstid sliderite jaoks
        AbsoluteLayout.SetLayoutBounds(lblR, new Rect(20, 150, 80, 20));
        AbsoluteLayout.SetLayoutBounds(lblG, new Rect(20, 200, 80, 20));
        AbsoluteLayout.SetLayoutBounds(lblB, new Rect(20, 250, 80, 20));

        // Sliderid + stepperid
        AbsoluteLayout.SetLayoutBounds(slR, new Rect(20, 170, 240, 40));
        AbsoluteLayout.SetLayoutBounds(stR, new Rect(270, 170, 90, 40));

        AbsoluteLayout.SetLayoutBounds(slG, new Rect(20, 220, 240, 40));
        AbsoluteLayout.SetLayoutBounds(stG, new Rect(270, 220, 90, 40));

        AbsoluteLayout.SetLayoutBounds(slB, new Rect(20, 270, 240, 40));
        AbsoluteLayout.SetLayoutBounds(stB, new Rect(270, 270, 90, 40));

        // Random nupp
        AbsoluteLayout.SetLayoutBounds(btnRandom, new Rect(0.5, 0.40, 200, 45));
        AbsoluteLayout.SetLayoutFlags(btnRandom, AbsoluteLayoutFlags.PositionProportional);

        // Ruudu omadused
        AbsoluteLayout.SetLayoutBounds(lblSize, new Rect(20, 360, 150, 25));
        AbsoluteLayout.SetLayoutBounds(stSize, new Rect(180, 355, 160, 40));

        AbsoluteLayout.SetLayoutBounds(lblRadius, new Rect(20, 405, 150, 25));
        AbsoluteLayout.SetLayoutBounds(stRadius, new Rect(180, 400, 160, 40));

        AbsoluteLayout.SetLayoutBounds(lblOpacity, new Rect(20, 450, 160, 25));
        AbsoluteLayout.SetLayoutBounds(stOpacity, new Rect(180, 445, 160, 40));

        // Suur värviruut all
        AbsoluteLayout.SetLayoutBounds(colorFrame, new Rect(0.5, 0.88, 280, 280));
        AbsoluteLayout.SetLayoutFlags(colorFrame, AbsoluteLayoutFlags.PositionProportional);

        Content = new ScrollView { Content = abs };

        // Algväärtus (magenta)
        SetRgb(255, 0, 255);
        UpdatePreview();
        UpdateChannelBoxes(); // <-- oluline
    }

    Frame MakeSmallBox(Color c) => new Frame
    {
        WidthRequest = 55,
        HeightRequest = 55,
        CornerRadius = 12,
        HasShadow = false,
        BackgroundColor = c
    };

    Slider MakeSlider() => new Slider { Minimum = 0, Maximum = 255, Value = 0 };

    Stepper MakeStepperRGB() => new Stepper { Minimum = 0, Maximum = 255, Increment = 1, Value = 0 };

    void OnSliderChanged(object? sender, ValueChangedEventArgs e)
    {
        if (_syncing) return;
        _syncing = true;

        if (sender == slR) stR.Value = Convert.ToInt32(e.NewValue);
        else if (sender == slG) stG.Value = Convert.ToInt32(e.NewValue);
        else if (sender == slB) stB.Value = Convert.ToInt32(e.NewValue);

        UpdateColor();
        UpdateChannelBoxes(); // <-- uuendab ülemisi ruute
        _syncing = false;
    }

    void OnStepperChanged(object? sender, ValueChangedEventArgs e)
    {
        if (_syncing) return;
        _syncing = true;

        if (sender == stR) slR.Value = Convert.ToInt32(e.NewValue);
        else if (sender == stG) slG.Value = Convert.ToInt32(e.NewValue);
        else if (sender == stB) slB.Value = Convert.ToInt32(e.NewValue);

        UpdateColor();
        UpdateChannelBoxes(); // <-- uuendab ülemisi ruute
        _syncing = false;
    }

    void UpdateColor()
    {
        int r = Convert.ToInt32(slR.Value);
        int g = Convert.ToInt32(slG.Value);
        int b = Convert.ToInt32(slB.Value);

        colorFrame.BackgroundColor = Color.FromRgb(r, g, b);

        lblInfo.Text = $"R: {r}  G: {g}  B: {b}";
        lblR.Text = "R: " + r;
        lblG.Text = "G: " + g;
        lblB.Text = "B: " + b;
    }

    // ÜLAL 3 RUUTU: näitavad eraldi kanalit
    void UpdateChannelBoxes()
    {
        int r = Convert.ToInt32(slR.Value);
        int g = Convert.ToInt32(slG.Value);
        int b = Convert.ToInt32(slB.Value);

        // ainult vastav kanal, teised 0
        boxR.BackgroundColor = Color.FromRgb(r, 0, 0);
        boxG.BackgroundColor = Color.FromRgb(0, g, 0);
        boxB.BackgroundColor = Color.FromRgb(0, 0, b);
    }

    void UpdatePreview()
    {
        double size = stSize.Value;
        colorFrame.WidthRequest = size;
        colorFrame.HeightRequest = size;
        lblSize.Text = "Suurus: " + Convert.ToInt32(size);

        colorFrame.CornerRadius = (float)stRadius.Value;
        lblRadius.Text = "Nurgad: " + Convert.ToInt32(stRadius.Value);

        colorFrame.Opacity = stOpacity.Value;
        lblOpacity.Text = "Läbipaistvus: " + stOpacity.Value.ToString("0.0");
    }

    void SetRgb(int r, int g, int b)
    {
        _syncing = true;
        slR.Value = r; slG.Value = g; slB.Value = b;
        stR.Value = r; stG.Value = g; stB.Value = b;
        UpdateColor();
        UpdateChannelBoxes();
        _syncing = false;
    }

    async Task RandomColorAsync()
    {
        var rnd = new Random();
        SetRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        await Task.CompletedTask;
    }
}
