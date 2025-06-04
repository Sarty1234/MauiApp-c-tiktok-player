namespace MauiApp_c__tiktok_player
{
    public partial class MainPage : ContentPage
    {
        // Declares variables
        string[] videoIds = new string[0];
        Random rnd = new Random();
        int randomId = 0;
        string curentvideoID = "7512001022907206968";    // Tutorial video Id


        public MainPage()
        {
            InitializeComponent();

            // Positions StartButton at center
            StartButton.Margin = new Thickness(0, 300, 0, 0);

            // Hides webview, video navigation container and buttons
            //MainWebView.MaximumHeightRequest = 0;
            NextButton.MaximumHeightRequest = 0;
            ReloadVideoButton.MaximumHeightRequest = 0;
            VideoNavigationContainer.MaximumHeightRequest = 0;

            // Sets link to tutorial video
            MainWebView.Source = $"https://www.tiktok.com/embed/{curentvideoID}";
        }


        /// <summary>
        /// Function is called when next video button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextVideoButton_Clicked(object sender, EventArgs e)
        {
            if (videoIds.Length < 1)  //Over here checks if there is no video link in videoIds
            {
                // If there is no link in array it calls file dialog to fill videoIds
                PickVideosFile(PickOptions.Default);
            }
            else
            {
                // If there is at least one link it will pick one random
                randomId = rnd.Next(videoIds.Length);

                // Here it assigns new url for webview
                MainWebView.Source = $"https://www.tiktok.com/embed/{videoIds[randomId]}";

                // Here it saves curent video Id and deletes it from array to avoid reiterance
                curentvideoID = videoIds[randomId];
                videoIds = videoIds.Where(url => url != videoIds[randomId]).ToArray();
            }
        }


        /// <summary>
        /// Function is called when reload button is pressed. It will set link to last embed video Id saved in curentvideoID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadVideoButton_Clicked(object sender, EventArgs e)
        {
            MainWebView.Source = $"https://www.tiktok.com/embed/{curentvideoID}";
        }


        /// <summary>
        /// This function sets scale and position for all UI elements
        /// </summary>
        private void SETUIScales()
        {
            // Hides StartButton
            StartButton.MaximumHeightRequest = -1;
            StartButton.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            StartButton.Margin = new Thickness(0, 0, 0, 0);

            // Sets height of webview
            MainWebView.MaximumHeightRequest = Container.Height * 0.9;

            // Shows Navigation Container
            VideoNavigationContainer.MaximumHeightRequest = Container.Height * 0.1;
            VideoNavigationContainer.HeightRequest = Container.Height * 0.1;

            // Shows Reload video button and changes its size
            ReloadVideoButton.MaximumHeightRequest = Container.Height * 0.1;
            ReloadVideoButton.HeightRequest = Container.Height * 0.1;
            ReloadVideoButton.WidthRequest = Container.Height * 0.1;
            ReloadVideoButton.BackgroundColor = Colors.Black;

            // Shows Next video button and changes its size
            NextButton.MaximumHeightRequest = Container.Height * 0.1;
            NextButton.HeightRequest = Container.Height * 0.1;
            NextButton.WidthRequest = Container.Width - Container.Height * 0.1;
            NextButton.BackgroundColor = Colors.Black;
        }


        /// <summary>
        /// This functions opens file dialog and parses all video links saving them in videoIds array
        /// </summary>
        /// <param name="options">File pick options(just use defoult)</param>
        /// <returns></returns>
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


        /// <summary>
        /// Function is called when start button is loaded. If button size is not 0 function will call SETUIScales()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_SizeChanged(object sender, EventArgs e)
        {
            double i = 0;
            i = MainWebView.Height;

            if (i > 0)
            {
                SETUIScales();
            }
        }
    }

}
