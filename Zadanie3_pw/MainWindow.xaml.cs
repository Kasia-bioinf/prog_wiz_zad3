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
using Microsoft.Win32;
using System.IO;

namespace Zadanie3_pw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string namE;
        public int iD = 1;
        public int counT;
        public MainWindow()
        {
            InitializeComponent();
            /*List<napoje> items = new List<napoje>();
            items.Add(new napoje() { name = "John", id = 42, count = 1 });
            items.Add(new napoje() { name = "Jane", id = 39, count = 3 });
            items.Add(new napoje() { name = "Sammy", id = 7, count = 2 });
            listView.ItemsSource = items;*/

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Add_window add_Window = new Add_window(namE,counT);
            add_Window.ShowDialog();
            this.Hide();

            namE = add_Window.new_name;
            counT = add_Window.new_count;

            //listView.Items.Add(new napoje() { name = namE, id = iD++, count = counT });
            List<napoje> items = new List<napoje>();
            items.Add(new napoje() { name = "John", id = 42, count = 1 });
            items.Add(new napoje() { name = "Jane", id = 39, count = 3 });
            items.Add(new napoje() { name = "Sammy", id = 7, count = 2 });
            listView.ItemsSource = items;
            listView.Items.Refresh();
        }


        public class napoje
        {
            public string name { get; set; }

            public int id { get; set; }

            public int count { get; set; }
        }

        private void zapis_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog new_file = new SaveFileDialog();
            new_file.Filter = "CSV file (*.csv)|Text file (*.txt)|*.txt|*.csv|All files (*.*)|*.*";

            new_file.ShowDialog();
            string savePathCSV = new_file.FileName;

            using (var output = new StreamWriter(savePathCSV))
            {
                foreach (napoje item in listView.Items)
                {
                    output.WriteLine("{0};{1};{2}", item.name, item.id, item.count);
                }
            }
        }

        private void odczyt_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();

            FileDialog new_file = new OpenFileDialog();
            new_file.ShowDialog();

            string inputPathCSV = new_file.FileName;

            string[] lines = File.ReadAllLines(inputPathCSV);

            foreach (var item in lines)
            {
                string[] data = item.Split(';');

                this.listView.Items.Add(new napoje { name = data[0], id = iD++, count = Int32.Parse(data[1]) });
            }
        }
    }
}
    





