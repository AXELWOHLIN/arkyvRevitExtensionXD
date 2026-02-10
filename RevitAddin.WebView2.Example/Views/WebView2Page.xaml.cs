using System.Windows.Controls;

namespace RevitAddin.WebView2.Example.Views
{
    public partial class WebView2Page : Page
    {
        public WebView2Page()
        {
            InitializeComponent();
            this.DataContext = ViewModel.Instance;
            this.Loaded += async (s, e) =>
            {
                try
                {
                    await webView.InitializeWebAsync();
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"WebView2 initialization failed: {ex.Message}");
                }
            };
            //this.Unloaded += (s, e) =>
            //{
            //    System.Console.WriteLine($"{this.GetHashCode()} \t Unloaded");
            //    webView.Dispose();
            //};
        }
    }
}
