using System.Collections.ObjectModel;
using System.Windows;
using ADO_Demo.DB.CRUDs;
using ADO_Demo.DB.Models;

namespace ADO_Demo.App
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Role> Roles { get; set; }
        public MainWindow()
        {
            var roles = new RoleCrud();
            Roles = new ObservableCollection<Role>(roles.GetAllRoles());
            
            InitializeComponent();
        }
    }
}
