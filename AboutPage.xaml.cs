﻿namespace MauiApp_c__tiktok_player
{
    public partial class AboutPage : ContentPage
    {
        int count = 0;

        public AboutPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            //if (count == 1)
                //CounterBtn.Text = $"Clicked {count} time";
            //else
                //CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void PointerGestureRecognizer_PointerPressed(object sender, PointerEventArgs e)
        {
            but.Text = "";
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            but.Text = "";
        }
    }

}
