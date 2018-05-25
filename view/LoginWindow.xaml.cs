using System.Windows;
using Managers;

namespace view
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        

        private void Login(object sender, RoutedEventArgs e)
        {
            if (GestionManagersIdentification.Login(Username.Text, Password.Text) == true)
            {

                MessageBox.Show("Vous etes connecte");
                MainWindow mainWindow = new MainWindow();
               

                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Vous etes deconnecte");

            }
        }
    }
}
