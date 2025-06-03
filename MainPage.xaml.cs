namespace MauiApp_c__tiktok_player
{
    public partial class MainPage : ContentPage
    {
        string[] videoIds = new string[0];
        Random rnd = new Random();


        public MainPage()
        {
            InitializeComponent();

            StartButton.Margin = new Thickness(0, 300, 0, 0);

            MainWebView.MaximumHeightRequest = 0;
            NextButton.MaximumHeightRequest = 0;
        }


        private void NextVideoButton_Clicked(object sender, EventArgs e)
        {
            if (videoIds.Length < 1)
            {
                PickVideosFile(PickOptions.Default);
            }
            else
            {
                MainWebView.Source = $"https://www.tiktok.com/embed/{videoIds[rnd.Next(videoIds.Length)]}";
            }
        }


        private void StartButton_Clicked(object sender, EventArgs e)
        {
            StartButton.MaximumHeightRequest = -1;
            StartButton.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            StartButton.Margin = new Thickness(0, 0, 0, 0);

            MainWebView.MaximumHeightRequest = Container.Height * 0.9;

            NextButton.MaximumHeightRequest = Container.Height * 0.1;
            NextButton.HeightRequest = Container.Height * 0.1;
            NextButton.BackgroundColor = Colors.Black;
        }


        public async Task<FileResult> PickVideosFile(PickOptions options)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("txt", StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (var line in File.ReadLines(result.FullPath))
                        {
                            if (line.StartsWith("Link: https://www.tiktokv.com/share/video/"))
                            {
                                videoIds = videoIds.Append(line.Replace("Link: https://www.tiktokv.com/share/video/", "").Replace("/", "")).ToArray();
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert", "Something went wrong", "ok");
            }

            return null;
        }
    }

}
