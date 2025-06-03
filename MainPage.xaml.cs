namespace MauiApp_c__tiktok_player
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MainWebView.MaximumHeightRequest = 650;
            NextButton.HeightRequest = 100;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MainWebView.Source = "https://www.tiktok.com/embed/7509945374615031096";
        }

        //MainWebView.Source = "https://www.tiktok.com/embed/7509945374615031096";
        //<PointerGestureRecognizer PointerMoved = "PointerGestureRecognizer_PointerMoved" />
        //DisplayAlert("Alert", "dragged", "ok");
        //<WebView x:Name="MainWebView" HorizontalOptions="Fill" VerticalOptions="Fill" Source="https://www.tiktok.com/embed/7510888508546944261"/>
    }

}
