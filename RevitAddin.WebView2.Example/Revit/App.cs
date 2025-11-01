using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.WebView2.Example.Views;
using ricaun.Revit.UI;
using System;

namespace RevitAddin.WebView2.Example.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("ARKYV Assistant");

            ribbonPanel.CreatePushButton<Commands.CommandDockablePane>("ARKYV")
                .SetToolTip("Open ARKYV Assistant as a dockable panel")
                .SetLargeImage("Resources/Revit.ico");

            if (int.TryParse(application.ControlledApplication.VersionNumber, out int versionNumber))
            {
                if (versionNumber >= 2024)
                    RegisterDockablePane(application);
            }

            return Result.Succeeded;
        }

        private static Guid DockablePaneGuid => new Guid("C36E3BC8-0985-4080-8E84-C10D6AB8D80A");
        private static DockablePaneId DockablePaneId => new DockablePaneId(DockablePaneGuid);
        public static void DockablePaneShow(UIApplication uiapp)
        {
            try
            {
                var dockablePane = uiapp.GetDockablePane(DockablePaneId);
                if (dockablePane == null)
                {
                    TaskDialog.Show("Error", "Dockable pane not found. It may not be registered properly.");
                    return;
                }
                
                if (dockablePane.IsShown())
                {
                    dockablePane.Hide();
                }
                else
                {
                    dockablePane.Show();
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error", $"Failed to show dockable pane: {ex.Message}");
            }
        }
        private void RegisterDockablePane(UIControlledApplication application)
        {
            try
            {
                if (DockablePane.PaneIsRegistered(DockablePaneId))
                    return;

                var provider = new DockablePanePageProvider(() => 
                {
                    var page = new WebView2Page();
                    return page;
                });
                
                application.RegisterDockablePane(DockablePaneId, "ARKYV Assistant", provider);
                
                // Show success message for debugging
                TaskDialog.Show("Success", "ARKYV Assistant dockable pane registered successfully!");
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Registration Error", $"Failed to register dockable pane: {ex.Message}\n\nStack trace: {ex.StackTrace}");
            }
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            return Result.Succeeded;
        }
    }
}