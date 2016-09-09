using System.Windows;

namespace CodeX
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            CodeX.Properties.Settings.Default.Save();
        }
    }
}
