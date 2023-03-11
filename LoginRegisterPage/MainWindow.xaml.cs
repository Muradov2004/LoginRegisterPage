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

namespace LoginRegisterPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (RegisterUserName.Text.Length >= 3 && RegisterPassword.Password.Length >= 4)
            {
                bool condition = true;
                foreach (var item in data)
                    if (RegisterUserName.Text == item.Key)
                    {
                        MessageBox.Show("UserName exist", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        condition = false;
                    }
                if (condition)
                {
                    data.Add(RegisterUserName.Text, RegisterPassword.Password);
                    MessageBox.Show("You are Registered", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else MessageBox.Show("Username or passsword is too short. Username would be at last 3 character.Password minimum -> 4 character", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            RegisterUserName.Clear();
            RegisterPassword.Clear();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool condition = true;
            foreach (var item in data)
                if (UserName.Text == item.Key)
                {
                    if (Password.Password == item.Value)
                        MessageBox.Show("You are Logged In", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Incorrect Password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    condition = false;
                }

            if (condition)
                MessageBox.Show("Username not found", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            UserName.Clear();
            Password.Clear();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) => Close();

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}
