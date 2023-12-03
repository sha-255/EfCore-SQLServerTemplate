using System.Windows;
using System.Windows.Controls;

namespace tst1
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        UsersContext usersContext = new();

        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User? user = usersContext.Users.Find(Login.Text);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
            if (user?.Password.Normalize().Trim() == Password.Password)
            {
                NavigationService.Navigate(new Main());
            }
            else
            {
                MessageBox.Show("Пароль неверен");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Reg());
        }
    }
}
