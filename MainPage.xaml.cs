namespace MauiApp_c__tiktok_player
{
    public partial class MainPage : ContentPage
    {
        DateTime lastClickTime = DateTime.Now;
        public MainPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            if ((DateTime.Now - lastClickTime).TotalMilliseconds < 1000)
            {
                MainWebView.Source = "https://www.tiktok.com/embed/7509945374615031096";
            }
            lastClickTime = DateTime.Now;
        }

        //MainWebView.Source = "https://www.tiktok.com/embed/7509945374615031096";
        //<PointerGestureRecognizer PointerMoved = "PointerGestureRecognizer_PointerMoved" />
        //DisplayAlert("Alert", "dragged", "ok");
        //<WebView x:Name="MainWebView" HorizontalOptions="Fill" VerticalOptions="Fill" Source="https://www.tiktok.com/embed/7510888508546944261"/>
    }

}
