using System.Windows;
using System.Windows.Controls;

namespace tst1
{
    /// <summary>
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        UsersContext context = new();

        public Reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.Users.Add(
                new User()
                {
                    Login = Login.Text,
                    Password = Password.Text
                });
            context.SaveChanges();
            MessageBox.Show("Пользователь зарегестрирован");
            NavigationService.Navigate(new Auth());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }
    }
}
