﻿using Microsoft.Win32;
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

        private void Bold_Checked(object sender, RoutedEventArgs e)
        {
            mainTextBox.FontWeight = FontWeights.Bold;
        }

        private void Bold_Unchecked(object sender, RoutedEventArgs e)
        {
            mainTextBox.FontWeight = FontWeights.Normal;
        }

        private void Italic_Checked(object sender, RoutedEventArgs e)
        {
            mainTextBox.FontStyle = FontStyles.Italic;
        }

        private void Italic_Unchecked(object sender, RoutedEventArgs e)
        {
            mainTextBox.FontStyle = FontStyles.Normal;
        }

        private void IncreaseFont_Click(object sender, RoutedEventArgs e)
        {
            if (mainTextBox.FontSize < 18)
            {
                mainTextBox.FontSize += 2;
            }
        }

        private void DecreaseFont_Click(object sender, RoutedEventArgs e)
        {
            if (mainTextBox.FontSize > 10)
            {
                mainTextBox.FontSize -= 2;
            }
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
                mainTextBox.FontSize = dlg.SelectedFontSize;
                mainTextBox.FontFamily = dlg.SelectedFontFamily;
            }
        }
    }
}
