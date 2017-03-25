using System.Windows;
using System.Windows.Media;

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
