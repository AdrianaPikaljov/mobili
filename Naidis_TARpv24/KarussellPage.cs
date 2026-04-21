using System.Collections.ObjectModel;

namespace Naidis_TARpv24;

public class KarussellPage : ContentPage
{
    public class CarouselItem
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }

    private CarouselView carouselView;
    private ObservableCollection<CarouselItem> items;
    private int position = 0;

    public KarussellPage()
    {
        Title = "Karussell - Interaktiivne";

        // Andmed
        items = new ObservableCollection<CarouselItem>
        {
            new CarouselItem { Title = "Tallinna vanalinn", ImageUrl = "https://picsum.photos/id/1031/600/400" },
            new CarouselItem { Title = "Merevaade", ImageUrl = "https://picsum.photos/id/1016/600/400" },
            new CarouselItem { Title = "Metsarada", ImageUrl = "https://picsum.photos/id/1020/600/400" }
        };

        // CarouselView
        carouselView = new CarouselView
        {
            ItemsSource = items,
            HeightRequest = 360,
            PeekAreaInsets = new Thickness(50, 0),
            Loop = true,

            ItemTemplate = new DataTemplate(() =>
            {
                var frame = new Frame
                {
                    CornerRadius = 20,
                    HasShadow = true,
                    Padding = 0,
                    Margin = new Thickness(10),
                    BackgroundColor = Colors.Black
                };

                var grid = new Grid();

                var image = new Image
                {
                    Aspect = Aspect.AspectFill
                };
                image.SetBinding(Image.SourceProperty, "ImageUrl");

                // Gradient overlay (muudetud värvid)
                var gradient = new BoxView
                {
                    Opacity = 0.6,
                    Background = new LinearGradientBrush
                    {
                        StartPoint = new Point(0, 1),
                        EndPoint = new Point(0, 0),
                        GradientStops =
                        {
                            new GradientStop(Colors.Black, 0),
                            new GradientStop(Colors.Transparent, 1)
                        }
                    }
                };

                var label = new Label
                {
                    TextColor = Colors.White,
                    FontSize = 22,
                    FontAttributes = FontAttributes.Bold,
                    Margin = new Thickness(15),
                    VerticalOptions = LayoutOptions.End
                };
                label.SetBinding(Label.TextProperty, "Title");

                grid.Children.Add(image);
                grid.Children.Add(gradient);
                grid.Children.Add(label);

                frame.Content = grid;

                // 👇 Klikitav kaart (interaktsioon)
                var tap = new TapGestureRecognizer();
                tap.Tapped += async (s, e) =>
                {
                    var item = (CarouselItem)frame.BindingContext;
                    await frame.ScaleTo(0.95, 100);
                    await frame.ScaleTo(1, 100);

                    await Application.Current.MainPage.DisplayAlert(
                        "Valitud pilt",
                        item.Title,
                        "OK");
                };

                frame.GestureRecognizers.Add(tap);

                // 👇 Swipe delete
                var swipe = new SwipeGestureRecognizer
                {
                    Direction = SwipeDirection.Left
                };

                swipe.Swiped += (s, e) =>
                {
                    var item = (CarouselItem)frame.BindingContext;
                    items.Remove(item);
                };

                frame.GestureRecognizers.Add(swipe);

                return frame;
            })
        };

        // IndicatorView
        var indicatorView = new IndicatorView
        {
            IndicatorColor = Colors.LightGray,
            SelectedIndicatorColor = Colors.MediumPurple,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 10)
        };

        carouselView.IndicatorView = indicatorView;

        // Lisa nupp
        var addButton = new Button
        {
            Text = "Lisa uus kaart",
            BackgroundColor = Colors.MediumPurple,
            TextColor = Colors.White
        };

        addButton.Clicked += async (s, e) =>
        {
            var newItem = new CarouselItem
            {
                Title = "Uus koht " + (items.Count + 1),
                ImageUrl = "https://picsum.photos/600/400?random=" + items.Count
            };

            items.Add(newItem);

            // fade-in efekt
            await carouselView.FadeTo(0, 100);
            carouselView.Position = items.Count - 1;
            await carouselView.FadeTo(1, 200);
        };

        // Auto-scroll (muudetud kiirus)
        Device.StartTimer(TimeSpan.FromSeconds(3), () =>
        {
            if (items.Count == 0) return false;

            position = (position + 1) % items.Count;
            carouselView.Position = position;

            return true;
        });

        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Padding = 20,
                Spacing = 15,
                Children =
                {
                    carouselView,
                    indicatorView,
                    addButton
                }
            }
        };
    }
}