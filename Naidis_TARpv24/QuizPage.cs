using Microsoft.Maui.Storage;

namespace Naidis_TARpv24;

public class QuizQuestion
{
    public string QuestionText { get; set; }
    public List<string> Options { get; set; }
    public string CorrectAnswer { get; set; }

    public QuizQuestion(string questionText, List<string> options, string correctAnswer)
    {
        QuestionText = questionText;
        Options = options;
        CorrectAnswer = correctAnswer;
    }
}

public class QuizPage : ContentPage
{
    VerticalStackLayout vst;
    Label titleLabel;
    Label infoLabel;
    Button startButton;

    string savedName = "";

    Dictionary<string, List<QuizQuestion>> quizData = new Dictionary<string, List<QuizQuestion>>()
    {
        {
            "Loodus",
            new List<QuizQuestion>()
            {
                new QuizQuestion("Mis on maailma suurim loom?",
                    new List<string> { "Sinivaal", "Elevant", "Hai", "Kaelkirjak" }, "Sinivaal"),

                new QuizQuestion("Mitu jalga on ämblikul?",
                    new List<string> { "6", "8", "10", "12" }, "8"),

                new QuizQuestion("Milline planeet on Päikesele kõige lähemal?",
                    new List<string> { "Veenus", "Maa", "Merkuur", "Marss" }, "Merkuur"),

                new QuizQuestion("Mis gaasi hingavad taimed sisse?",
                    new List<string> { "Hapnik", "Lämmastik", "Süsihappegaas", "Heelium" }, "Süsihappegaas"),

                new QuizQuestion("Milline loom on tuntud kui metsa kuningas?",
                    new List<string> { "Tiiger", "Lõvi", "Karu", "Hunt" }, "Lõvi"),

                new QuizQuestion("Mis aastaajal sajab kõige rohkem lund?",
                    new List<string> { "Kevad", "Suvi", "Sügis", "Talv" }, "Talv"),

                new QuizQuestion("Mis on meie planeedi nimi?",
                    new List<string> { "Marss", "Veenus", "Maa", "Jupiter" }, "Maa"),

                new QuizQuestion("Kas pingviin oskab lennata?",
                    new List<string> { "Jah", "Ei", "Ainult noorena", "Ainult talvel" }, "Ei"),

                new QuizQuestion("Milline loom annab meile piima?",
                    new List<string> { "Lammas", "Lehm", "Kana", "Part" }, "Lehm"),

                new QuizQuestion("Milline täht annab Maale valgust ja soojust?",
                    new List<string> { "Kuu", "Marss", "Päike", "Veenus" }, "Päike"),

                new QuizQuestion("Mitu päeva on nädalas?",
                    new List<string> { "5", "6", "7", "8" }, "7"),

                new QuizQuestion("Mis värvi on tavaliselt rohi?",
                    new List<string> { "Punane", "Sinine", "Roheline", "Must" }, "Roheline")
            }
        },
        {
            "Ajalugu",
            new List<QuizQuestion>()
            {
                new QuizQuestion("Kes oli Eesti esimene president?",
                    new List<string> { "Lennart Meri", "Konstantin Päts", "Toomas Hendrik Ilves", "Arnold Rüütel" }, "Konstantin Päts"),

                new QuizQuestion("Mis aastal algas Teine maailmasõda?",
                    new List<string> { "1918", "1939", "1945", "1929" }, "1939"),

                new QuizQuestion("Kes avastas Ameerika?",
                    new List<string> { "Napoleon", "Kolumbus", "Magellan", "Caesar" }, "Kolumbus"),

                new QuizQuestion("Mis aastal Eesti taasiseseisvus?",
                    new List<string> { "1989", "1990", "1991", "1992" }, "1991"),

                new QuizQuestion("Millises riigis elasid vaaraod?",
                    new List<string> { "Kreeka", "Itaalia", "Egiptus", "Hiina" }, "Egiptus"),

                new QuizQuestion("Mis müür langes 1989. aastal?",
                    new List<string> { "Hiina müür", "Berliini müür", "Rooma müür", "Tallinna müür" }, "Berliini müür"),

                new QuizQuestion("Kes oli Rooma esimene keiser?",
                    new List<string> { "Caesar", "Augustus", "Nero", "Pompeius" }, "Augustus"),

                new QuizQuestion("Kes oli Napoleon?",
                    new List<string> { "Kuningas", "Keiser", "Paavst", "Kirjanik" }, "Keiser"),

                new QuizQuestion("Millises sajandis elas Kolumbus?",
                    new List<string> { "10.", "12.", "15.", "18." }, "15."),

                new QuizQuestion("Kes ehitas püramiide?",
                    new List<string> { "Roomlased", "Egiptlased", "Viikingid", "Kreeklased" }, "Egiptlased"),

                new QuizQuestion("Milline laev uppus 1912. aastal?",
                    new List<string> { "Titanic", "Victoria", "Bismarck", "Santa Maria" }, "Titanic"),

                new QuizQuestion("Kes oli kuulus Vana-Rooma väejuht?",
                    new List<string> { "Caesar", "Newton", "Einstein", "Mozart" }, "Caesar")
            }
        },
        {
            "Geograafia",
            new List<QuizQuestion>()
            {
                new QuizQuestion("Mis on Eesti pealinn?",
                    new List<string> { "Tartu", "Tallinn", "Pärnu", "Narva" }, "Tallinn"),

                new QuizQuestion("Mis on maailma suurim ookean?",
                    new List<string> { "Atlandi ookean", "India ookean", "Vaikne ookean", "Jäämeri" }, "Vaikne ookean"),

                new QuizQuestion("Mis riigis asub Pariis?",
                    new List<string> { "Itaalia", "Hispaania", "Prantsusmaa", "Belgia" }, "Prantsusmaa"),

                new QuizQuestion("Mis on Soome pealinn?",
                    new List<string> { "Oslo", "Helsingi", "Stockholm", "Riia" }, "Helsingi"),

                new QuizQuestion("Mis on maailma kõrgeim mägi?",
                    new List<string> { "Alpid", "Mont Blanc", "Everest", "Kilimanjaro" }, "Everest"),

                new QuizQuestion("Mis manner on kõige suurem?",
                    new List<string> { "Euroopa", "Aafrika", "Aasia", "Lõuna-Ameerika" }, "Aasia"),

                new QuizQuestion("Mis riigis asub Rooma?",
                    new List<string> { "Portugal", "Itaalia", "Kreeka", "Austria" }, "Itaalia"),

                new QuizQuestion("Mis jõgi läbib Egiptust?",
                    new List<string> { "Amazonas", "Doonau", "Niilus", "Volga" }, "Niilus"),

                new QuizQuestion("Mis riigis asub Tokyo?",
                    new List<string> { "Hiina", "Jaapan", "Lõuna-Korea", "Tai" }, "Jaapan"),

                new QuizQuestion("Mis on Läti pealinn?",
                    new List<string> { "Vilnius", "Tallinn", "Riia", "Kaunas" }, "Riia"),

                new QuizQuestion("Milline riik on Eesti naaber?",
                    new List<string> { "Saksamaa", "Läti", "Prantsusmaa", "Poola" }, "Läti"),

                new QuizQuestion("Mis manner on Eesti?",
                    new List<string> { "Aasia", "Aafrika", "Euroopa", "Austraalia" }, "Euroopa")
            }
        }
    };

    public QuizPage()
    {
        Title = "Viktoriin";

        savedName = Preferences.Get("player_name", "");

        titleLabel = new Label
        {
            Text = "🧠 Viktoriinimäng",
            FontSize = 30,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
            TextColor = Colors.Black
        };

        infoLabel = new Label
        {
            Text = string.IsNullOrWhiteSpace(savedName)
                ? "Vajuta nuppu ja alusta testi"
                : $"Viimane mängija: {savedName}",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Center,
            TextColor = Colors.DarkSlateGray
        };

        startButton = new Button
        {
            Text = "Alusta viktoriini",
            FontSize = 24,
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60
        };

        startButton.Clicked += StartQuiz_Clicked;

        vst = new VerticalStackLayout
        {
            Padding = 30,
            Spacing = 25,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                titleLabel,
                infoLabel,
                startButton
            }
        };

        Content = new ScrollView
        {
            Content = vst
        };
    }

    private async void StartQuiz_Clicked(object sender, EventArgs e)
    {
        string name = await GetPlayerNameAsync();
        if (string.IsNullOrWhiteSpace(name))
            return;

        string category = await DisplayActionSheetAsync(
            "Vali viktoriini teema",
            "Loobu",
            null,
            quizData.Keys.ToArray()
        );

        if (string.IsNullOrWhiteSpace(category) || category == "Loobu")
        {
            await DisplayAlertAsync("Katkestatud", "Viktoriin jäi alustamata.", "OK");
            return;
        }

        int score = 0;
        int questionCount = 7;
        Random random = new Random();

        var questions = quizData[category]
            .OrderBy(q => random.Next())
            .Take(questionCount)
            .ToList();

        await DisplayAlertAsync("Alustame!", $"{name}, sinu valitud teema on: {category}", "OK");

        foreach (var question in questions)
        {
            var shuffledOptions = question.Options
                .OrderBy(x => random.Next())
                .ToArray();

            string answer = await DisplayActionSheetAsync(
                question.QuestionText,
                "Loobu",
                null,
                shuffledOptions
            );

            if (answer == "Loobu" || string.IsNullOrWhiteSpace(answer))
            {
                bool stopQuiz = await DisplayAlertAsync(
                    "Katkestamine",
                    "Kas soovid viktoriini katkestada?",
                    "Jah",
                    "Ei"
                );

                if (stopQuiz)
                {
                    await DisplayAlertAsync(
                        "Tulemus",
                        $"Katkestasid mängu. Punktid: {score}/{questions.Count}",
                        "OK"
                    );
                    infoLabel.Text = $"Viimane mängija: {name}";
                    return;
                }
                else
                {
                    shuffledOptions = question.Options
                        .OrderBy(x => random.Next())
                        .ToArray();

                    answer = await DisplayActionSheetAsync(
                        question.QuestionText,
                        "Loobu",
                        null,
                        shuffledOptions
                    );
                }
            }

            if (answer == question.CorrectAnswer)
            {
                score++;
                await DisplayAlertAsync("Õige!", "Tubli, vastus on õige.", "OK");
            }
            else
            {
                await DisplayAlertAsync("Vale", $"Õige vastus oli: {question.CorrectAnswer}", "OK");
            }
        }

        string hinnang = "";

        if (score == questions.Count)
            hinnang = "Suurepärane!";
        else if (score >= 5)
            hinnang = "Tubli töö!";
        else if (score >= 3)
            hinnang = "Päris hea!";
        else
            hinnang = "Harjuta veel!";

        await DisplayAlertAsync(
            "Viktoriin läbi",
            $"{name}, said {score}/{questions.Count} punkti.\n{hinnang}",
            "OK"
        );

        infoLabel.Text = $"Viimane tulemus: {name} - {score}/{questions.Count} punkti ({category})";

        bool playAgain = await DisplayAlertAsync(
            "Uus mäng?",
            "Kas soovid uuesti mängida?",
            "Jah",
            "Ei"
        );

        if (playAgain)
        {
            StartQuiz_Clicked(sender, e);
        }
    }

    private async Task<string> GetPlayerNameAsync()
    {
        string currentName = Preferences.Get("player_name", "");

        if (!string.IsNullOrWhiteSpace(currentName))
        {
            bool sameUser = await DisplayAlertAsync(
                "Kasutaja kontroll",
                $"Kas sina oled {currentName}?",
                "Jah",
                "Ei"
            );

            if (sameUser)
                return currentName;
        }

        string newName = await DisplayPromptAsync(
            "Tere!",
            "Sisesta oma nimi:",
            "OK",
            "Loobu",
            "nimi"
        );

        if (string.IsNullOrWhiteSpace(newName))
        {
            await DisplayAlertAsync("Hoiatus", "Nime ei sisestatud.", "OK");
            return "";
        }

        newName = newName.Trim();
        Preferences.Set("player_name", newName);
        savedName = newName;

        return newName;
    }
}