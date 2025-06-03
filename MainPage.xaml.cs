namespace MauiApp_c__tiktok_player
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            //MainWebView.Source = "https://www.tiktok.com/embed/7509945374615031096";
            //DisplayAlert("Alert", "dragged", "ok");
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            MainWebView.Source = "https://www.tiktok.com/embed/7509945374615031096";
            //DisplayAlert("Alert", "dragged", "ok");
        }

        //MainWebView.Source = "https://www.tiktok.com/embed/7509945374615031096";
        //<PointerGestureRecognizer PointerMoved = "PointerGestureRecognizer_PointerMoved" />
        //DisplayAlert("Alert", "dragged", "ok");
        //<WebView x:Name="MainWebView" HorizontalOptions="Fill" VerticalOptions="Fill" Source="https://www.tiktok.com/embed/7510888508546944261"/>
    }

}
