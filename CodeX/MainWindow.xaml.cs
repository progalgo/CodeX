using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CodeX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainTextBox.Lines = new List<string> { "Test text", "Another line" };
        }

        private void OpenCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;

            bool? res = dialog.ShowDialog(this);
            if (res == true)
            {
                //mainTextBox.Text = System.IO.File.ReadAllText(dialog.FileName);
            }
        }

        private void OpenCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SelectFont_Click(object sender, RoutedEventArgs e)
        {
            FontDialog dlg = new FontDialog();

            dlg.Owner = this;
            bool? res = dlg.ShowDialog();

            if (res == true)
            {
                var fs = dlg.SelectedFontSize;
                var ff = dlg.SelectedFontFamily;

                if (fs.HasValue)
                {
                    Properties.Settings.Default.FontSize = fs.Value;
                }

                if (ff != null)
                {
                    Properties.Settings.Default.FontFamily = dlg.SelectedFontFamily;
                }
            }
        }
    }
}
