﻿using ScannerMot.Utilities;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
namespace ScannerMot.Pages
{
    public partial class ScannerPage : ContentPage
    {

        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;
        public ScannerPage() : base()
        {
            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            zxing.OnScanResult += result =>
               Device.BeginInvokeOnMainThread(async () =>
               {

                   // Stop analysis until we navigate away so we don't keep reading barcodes
                   zxing.IsAnalyzing = false;

                   VariablesLocales.Room = result.Text;
                   // Show an alert
                   // await DisplayAlert("Scanned Barcode", result.Text, "OK");

                   // Navigate away
                   await Navigation.PopAsync();
               });

            overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Scanning will happen automatically",
                ShowFlashButton = zxing.HasTorch,
            };
            overlay.FlashButtonClicked += (sender, e) =>
            {
                zxing.IsTorchOn = !zxing.IsTorchOn;
            };
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            grid.Children.Add(zxing);
            grid.Children.Add(overlay);

            // The root page of your application
            Content = grid;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }

    }
}
