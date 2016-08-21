using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        private void OpenCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;

            bool? res = dialog.ShowDialog(this);
            if (res == true)
            {
                mainTextBox.Text = System.IO.File.ReadAllText(dialog.FileName);
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
                    mainTextBox.FontSize = fs.Value;
                }

                if (ff != null)
                {
                    mainTextBox.FontFamily = dlg.SelectedFontFamily;
                }
            }
        }
    }
}
