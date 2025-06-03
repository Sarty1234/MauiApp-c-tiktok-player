namespace MauiApp_c__tiktok_player
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            StartButton.Margin = new Thickness(0, 300, 0, 0);

            MainWebView.MaximumHeightRequest = 0;
            NextButton.MaximumHeightRequest = 0;
        }

        private void NextVideoButton_Clicked(object sender, EventArgs e)
        {
            MainWebView.Source = "https://www.tiktok.com/embed/7509945374615031096";
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            StartButton.MaximumHeightRequest = -1;
            StartButton.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            StartButton.Margin = new Thickness(0, 0, 0, 0);

            MainWebView.MaximumHeightRequest = Container.Height * 0.9;

            NextButton.MaximumHeightRequest = Container.Height - MainWebView.Height;
            NextButton.HeightRequest = Container.Height - MainWebView.Height;
            NextButton.BackgroundColor = Colors.Black;
        }
    }

}
