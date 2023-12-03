using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

namespace tst1
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        UsersContext context = new();

        public Main()
        {
            InitializeComponent();
            ApplyView();
            AddButton.Click += (s, e) => AddUser(new User()
            {
                Login = AddLogin.Text,
                Password = AddPassword.Text
            });
            RemoveButton.Click += (s, e) => RemoveUser(RemoveLogin.Text);
        }

        private async void ApplyView()
            => ListView.ItemsSource = await context.Users.ToListAsync();

        private void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            ApplyView();
        }

        private void RemoveUser(string loginKey)
        {
            var user = context.Users.Find(loginKey);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
            context.Users.Remove(user);
            context.SaveChanges();
            ApplyView();
        }

        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="loginKey"></param>
        /// <param name="password"></param>
        private void ChangeUser(string loginKey, string password)
        {
            var user = context.Users.Find(loginKey);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
            user.Password = password;
            context.Users.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
            ApplyView();
        }

        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="loginKey"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        private void ChangeUser(string loginKey, string login, string password)
        {
            RemoveUser(loginKey);
            AddUser(new User()
            {
                Login = login,
                Password = password
            });
        }
    }
}
