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
using System.Windows.Shapes;

namespace CodeX
{
    /// <summary>
    /// Interaction logic for FontDialog.xaml
    /// </summary>
    public partial class FontDialog : Window
    {
        public FontDialog()
        {
            InitializeComponent();

            cb_FontFamily.ItemsSource = Fonts.SystemFontFamilies;
            cb_Size.ItemsSource = new int[] { 9, 10, 11, 12, 14, 16 };
        }

        public double? SelectedFontSize
        { get { return (int?)cb_Size.SelectedValue; } }

        public FontFamily SelectedFontFamily
        { get { return (FontFamily)cb_FontFamily.SelectedValue; } }

        private void b_OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
