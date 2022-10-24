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

namespace WpfApp14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Entities04 connection = new Entities04(); // Entities04 это подключение к базе. За место него подставишь своё
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Authorize_Click(object sender, RoutedEventArgs e)
        {
            Entities04 connection = new Entities04(); //Подключение к базе
            try
            {
                var patientObj = connection.Materials.FirstOrDefault(x => x.Login == Log.Text && x.Password == Pass.Password);//После connection идёт название таблицы из которой хочешь взять информацию. Login - поле таблицы из базы; password - тоже поле. Log.Text и Pass.Password названия текст боксов на странице MainWindow
                if (patientObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Class1.Login = patientObj.Login;
            
                    //Переход на другую страницу
                    Reception1 reception1 = new Reception1();
                    reception1.Show();
                    //Закрытие
                    Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая работа приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
