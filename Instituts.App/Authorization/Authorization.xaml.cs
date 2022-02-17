using Instituts.DB.Lib;
using System;
using System.Windows;

namespace Instituts.App.Authorization
{
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();

            
        }

        private void ButtonAuth_Click(object sender, RoutedEventArgs e)
        {
            /*var login = InputLogin.Text;
            var password = InputPassword.Password;

            var db = new DbInstituts();
            var account = db.TabAccounts.FirstOrDefault(a => a.Login == login && a.Password == password);

            if (account is null)
            {
                MessageBox.Show("Неправильно ввели логин и пароль!", "!!! ERROR !!!");
            }
            else
            {
                MessageBox.Show("Добро пожаловать!");
                var main = new MainWindow(account);
                main.Show();
                Close();
            }*/
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
