
using System.Windows.Controls;

namespace RevitAddin.WebView2.Example.Views
{
    public partial class WebView2Page : Page
    {
        public WebView2Page()
        {
            try
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
                        // Show error in UI
                        Autodesk.Revit.UI.TaskDialog.Show("WebView2 Error", $"Failed to initialize WebView2: {ex.Message}");
                    }
                };
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"WebView2Page constructor failed: {ex.Message}");
                Autodesk.Revit.UI.TaskDialog.Show("Page Error", $"Failed to create WebView2Page: {ex.Message}");
            }
            //this.Unloaded += (s, e) =>
            //{
            //    System.Console.WriteLine($"{this.GetHashCode()} \t Unloaded");
            //    webView.Dispose();
            //};
        }
    }
}
