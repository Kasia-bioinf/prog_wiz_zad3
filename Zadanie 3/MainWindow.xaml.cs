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

namespace Zadanie_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            List<napoje> items = new List<napoje>();
            items.Add(new napoje() { Name = "John", ID = 42, Count = 1 });
            items.Add(new napoje() { Name = "Jane", ID = 39, Count = 3 });
            items.Add(new napoje() { Name = "Sammy", ID = 7, Count = 2 });
            listView.ItemsSource = items;

        }
       
        private void add_Click(object sender, RoutedEventArgs e)
        {
            Add_window add_Window = new Add_window();
            add_Window.Show();
            this.Hide();
        }


        public class napoje
        {
            public string Name { get; set; }

            public int ID { get; set; }

            public int Count { get; set; }
        }


    }
}
