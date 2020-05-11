using System;
using System.IO;
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
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;

namespace LR3_2
{  
    public partial class MainWindow : Window
    {
        ObservableCollection<string> resalt;
        List<string> positions, sityes, streets;
        Person person;
        BinaryFormatter formatter;
        public MainWindow()
        {
            InitializeComponent();

            positions = new List<string> { "директор", "бухгалтер", "грузчик"};
            ComboPosition.ItemsSource = positions;

            sityes = new List<string> { "Минск", "Лида", "Гродно" };
            ComboSity.ItemsSource = sityes;

            streets = new List<string> { "Тышкевичей", "Купревича", "Ленина" };
            ComboStreet.ItemsSource = streets;

            resalt = new ObservableCollection<string>();
            MyListBox.DataContext = resalt;

            person = new Person();
            MainStac.DataContext = person;
            // создаем объект BinaryFormatter
            formatter = new BinaryFormatter();
        }

        // Функция обновления содержимого комбобоксов
        public void UpdateItemsSource (ComboBox combo, string item, List<string> list)
        {
            if (list.IndexOf(item) == -1) // при отсутсвии в комбо элемента, добавим его туда
            {
                list.Add(item);
                combo.ItemsSource = null;
                combo.ItemsSource = list;
            }     
        }
        private void WritePerson_Click(object sender, RoutedEventArgs e)
        {
            // обновление перечней комбобоксов по данным прочитанным из самих же комбобоксов
            UpdateItemsSource(ComboPosition, ComboPosition.Text, positions);
            UpdateItemsSource(ComboSity, ComboSity.Text, sityes);
            UpdateItemsSource(ComboStreet, ComboStreet.Text, streets);
         
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                resalt.Clear();
                fs.Position = fs.Length;
                formatter.Serialize(fs, person);
                resalt.Add("Объект сериализован и записан в файл");
            }
        }

        private void ReadPerson_Click(object sender, RoutedEventArgs e)
        {
            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                resalt.Clear();
                while ( fs.Length != fs.Position)
                {
                    Person newPerson = (Person)formatter.Deserialize(fs);

                    // обновление перечней комбобоксов по данным прочитанным из файла
                    UpdateItemsSource(ComboPosition, newPerson.Position, positions);
                    UpdateItemsSource(ComboSity, newPerson.Sity, sityes);
                    UpdateItemsSource(ComboStreet, newPerson.Street, streets);

                    resalt.Add(newPerson.ToString());
                }
                resalt.Add("Объекты успешно прочитаны из файла и десериализованы!");              
            }
        }
    }
}
