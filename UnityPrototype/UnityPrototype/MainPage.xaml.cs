using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace UnityPrototype
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
            // Create a WebView to display Unity WebGL content
            var webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "ms-appx-web:///Resources/UnityWebGL/index.html"  // Path to the HTML file
                }
            };

            // Add the WebView to the page content
            Content = webView;
        }
    }
}

