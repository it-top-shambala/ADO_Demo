using System;
using System.Collections.Generic;
using ADO_Demo.DB.Models;
using ADO_Demo.DB.CRUDs;
using System.Windows;
using System.Collections.ObjectModel;



namespace ADO_Demo.App
{
    public partial class AuthWindow : Window
    {
        public ObservableCollection<Account> Accounts { get; set; }

        public Account accountAuth;
        public AuthWindow()
        {
            InitializeComponent();
        }


        private void ButtonAuthClick(object sender, RoutedEventArgs e)
        {

            string login = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Поля не заполнены!");
                return;
            }


            var accounts = new AccountCrud();
            Accounts = new ObservableCollection<Account>(accounts.GetAllAccounts());

            accountAuth = null;

            foreach (var account in Accounts)
            { 
                if (account.Login==login&&account.Password==password)
                    accountAuth = account;
            }

            if (accountAuth == null)
            { 
                MessageBox.Show($"Неправильно введен логин или пароль!");          
            }
            else 
            { 
 
                MainWindow mainWindow = new MainWindow(accountAuth);
                mainWindow.Show();
                Close();
                     
            }
        }
    }
}
