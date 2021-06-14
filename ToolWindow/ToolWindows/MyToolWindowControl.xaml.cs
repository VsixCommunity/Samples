using Community.VisualStudio.Toolkit;
using System.Windows;
using System.Windows.Controls;

namespace ToolWindow
{
    public partial class MyToolWindowControl : UserControl
    {
        public MyToolWindowControl(EnvDTE80.DTE2 dte)
        {
            InitializeComponent();

            lblHeadline.Content = $"Visual Studio v{dte.Version}";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            VS.Notifications.ShowMessage("ToolWindow", "Button clicked");
        }
    }
}