using System.Collections.ObjectModel;
using System.Windows;
using ADO_Demo.DB.CRUDs;
using ADO_Demo.DB.Models;

namespace ADO_Demo.App
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<User> Users { get; set; }
        public MainWindow(Account authUser)
        {
            var users = new UserCrud();
            string sqlQuery=string.Empty;
            switch (authUser.Role_Id)
            {
                case 1:
                    sqlQuery = $"SELECT tab_accounts.id AS 'id', first_name, last_name, role, email FROM tab_users  JOIN tab_accounts ON tab_users.id = tab_accounts.id  JOIN tab_roles ON tab_accounts.role_id = tab_roles.id JOIN tab_user_emails ON tab_user_emails.user_id = tab_users.id WHERE tab_accounts.id={authUser.Id};";
                    break;
                case 2:
                    sqlQuery = $"SELECT tab_accounts.id AS 'id', first_name, last_name, role, email FROM tab_users JOIN tab_accounts ON tab_users.id = tab_accounts.id  JOIN tab_roles ON tab_accounts.role_id = tab_roles.id JOIN tab_user_emails ON tab_user_emails.user_id = tab_users.id WHERE tab_accounts.id={authUser.Id};";
                    break;
                case 3:                    
                    sqlQuery = "SELECT tab_accounts.id AS 'id', first_name, last_name, role, email FROM tab_users JOIN tab_accounts ON tab_users.id = tab_accounts.id  JOIN tab_roles ON tab_accounts.role_id = tab_roles.id JOIN tab_user_emails ON tab_user_emails.user_id = tab_users.id;";
                    break;
                default:

                    break;
            
            }
            Users = new ObservableCollection<User>(users.GetUsers(sqlQuery));
            
            InitializeComponent();
        }
    }
}
