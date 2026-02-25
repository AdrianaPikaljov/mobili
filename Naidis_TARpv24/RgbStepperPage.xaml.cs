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
    Label lblSize, lblRadius;
    Stepper stSize, stRadius;

    Frame colorFrame;
    Button btnRandom;

    AbsoluteLayout abs;


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

        lblR = new Label { Text = "R: 0" };
        lblG = new Label { Text = "G: 0" };
        lblB = new Label { Text = "B: 0" };

        slR = MakeSlider();
        slG = MakeSlider();
        slB = MakeSlider();

        stR = MakeStepperRGB();
        stG = MakeStepperRGB();
        stB = MakeStepperRGB();

        boxR = MakeSmallBox(Color.FromRgb(0, 0, 0));
        boxG = MakeSmallBox(Color.FromRgb(0, 0, 0));
        boxB = MakeSmallBox(Color.FromRgb(0, 0, 0));

        colorFrame = new Frame
        {
            WidthRequest = 260,
            HeightRequest = 260,
            CornerRadius = 25,
            HasShadow = false,
            BackgroundColor = Color.FromRgb(0, 0, 0)
        };

        btnRandom = new Button
        {
            Text = "Juhuslik värv",
            CornerRadius = 12
        };
        btnRandom.Clicked += async (s, e) => await RandomColorAsync();

        lblSize = new Label { Text = "Suurus: 260" };
        lblRadius = new Label { Text = "Nurgad: 25" };

        stSize = new Stepper { Minimum = 120, Maximum = 250, Increment = 10, Value = 180 };
        stRadius = new Stepper { Minimum = 0, Maximum = 80, Increment = 5, Value = 25 };

        stSize.ValueChanged += (s, e) => UpdatePreview();
        stRadius.ValueChanged += (s, e) => UpdatePreview();

        slR.ValueChanged += OnSliderChanged;
        slG.ValueChanged += OnSliderChanged;
        slB.ValueChanged += OnSliderChanged;

        stR.ValueChanged += OnStepperChanged;
        stG.ValueChanged += OnStepperChanged;
        stB.ValueChanged += OnStepperChanged;

        abs = new AbsoluteLayout();

        abs.Children.Add(lblTitle);
        abs.Children.Add(lblInfo);

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

        abs.Children.Add(colorFrame);
        abs.Children.Add(btnRandom);

        // Paigutus

        AbsoluteLayout.SetLayoutBounds(lblTitle, new Rect(0.5, 15, 200, 30));
        AbsoluteLayout.SetLayoutFlags(lblTitle, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(lblInfo, new Rect(0.5, 45, 280, 25));
        AbsoluteLayout.SetLayoutFlags(lblInfo, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(boxR, new Rect(60, 80, 55, 55));
        AbsoluteLayout.SetLayoutBounds(boxG, new Rect(130, 80, 55, 55));
        AbsoluteLayout.SetLayoutBounds(boxB, new Rect(200, 80, 55, 55));

        AbsoluteLayout.SetLayoutBounds(lblR, new Rect(20, 150, 80, 20));
        AbsoluteLayout.SetLayoutBounds(lblG, new Rect(20, 200, 80, 20));
        AbsoluteLayout.SetLayoutBounds(lblB, new Rect(20, 250, 80, 20));

        AbsoluteLayout.SetLayoutBounds(slR, new Rect(20, 170, 240, 40));
        AbsoluteLayout.SetLayoutBounds(stR, new Rect(270, 170, 90, 40));

        AbsoluteLayout.SetLayoutBounds(slG, new Rect(20, 220, 240, 40));
        AbsoluteLayout.SetLayoutBounds(stG, new Rect(270, 220, 90, 40));

        AbsoluteLayout.SetLayoutBounds(slB, new Rect(20, 270, 240, 40));
        AbsoluteLayout.SetLayoutBounds(stB, new Rect(270, 270, 90, 40));

        AbsoluteLayout.SetLayoutBounds(lblSize, new Rect(20, 360, 150, 25));
        AbsoluteLayout.SetLayoutBounds(stSize, new Rect(180, 355, 160, 40));

        AbsoluteLayout.SetLayoutBounds(lblRadius, new Rect(20, 405, 150, 25));
        AbsoluteLayout.SetLayoutBounds(stRadius, new Rect(180, 400, 160, 40));

        // Suur värviruut
        AbsoluteLayout.SetLayoutBounds(colorFrame, new Rect(0.5, 0.88, 280, 280));
        AbsoluteLayout.SetLayoutFlags(colorFrame, AbsoluteLayoutFlags.PositionProportional);

        // Random nupp värviruudu all
        AbsoluteLayout.SetLayoutBounds(btnRandom, new Rect(0.5, 0.97, 200, 50));
        AbsoluteLayout.SetLayoutFlags(btnRandom, AbsoluteLayoutFlags.PositionProportional);

        Content = new ScrollView { Content = abs };

        SetRgb(255, 0, 255);
        UpdatePreview();
        UpdateChannelBoxes();
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
        int value = Convert.ToInt32(e.NewValue);

        if (sender == slR && stR.Value != value)
            stR.Value = value;
        else if (sender == slG && stG.Value != value)
            stG.Value = value;
        else if (sender == slB && stB.Value != value)
            stB.Value = value;

        UpdateColor();
        UpdateChannelBoxes();
    }

    void OnStepperChanged(object? sender, ValueChangedEventArgs e)
    {
        int value = Convert.ToInt32(e.NewValue);

        if (sender == stR && slR.Value != value)
            slR.Value = value;
        else if (sender == stG && slG.Value != value)
            slG.Value = value;
        else if (sender == stB && slB.Value != value)
            slB.Value = value;

        UpdateColor();
        UpdateChannelBoxes();
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

    void UpdateChannelBoxes()
    {
        int r = Convert.ToInt32(slR.Value);
        int g = Convert.ToInt32(slG.Value);
        int b = Convert.ToInt32(slB.Value);

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
    }

    void SetRgb(int r, int g, int b)
    {
        slR.Value = r;
        slG.Value = g;
        slB.Value = b;

        stR.Value = r;
        stG.Value = g;
        stB.Value = b;

        UpdateColor();
        UpdateChannelBoxes();
    }

    async Task RandomColorAsync()
    {
        var rnd = new Random();
        SetRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        await Task.CompletedTask;
    }
}