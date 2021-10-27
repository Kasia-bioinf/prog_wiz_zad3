using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Zadanie3_pw
{
    /// <summary>
    /// Logika interakcji dla klasy Add_window.xaml
    /// </summary>
    public partial class Add_window : Window
    {
        public string new_name = "name";
        public int new_count = 0;
        public Add_window(string name, int count)
        {
            InitializeComponent();
            this.new_name = name;
            this.new_count = count;
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            new_name = name.Text;
        }

        private void count_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(count.Text, out new_count))
            {
                new_count = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Hide();
        }
    }
}




