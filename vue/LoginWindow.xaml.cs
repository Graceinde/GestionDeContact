﻿using System;
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
using System.Windows.Shapes;
using Entites;
using Managers;

namespace vue
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
                //MainWindow mainWindow = new MainWindow();

                //Show();
                //Close();
            }
            else
            {
                MessageBox.Show("Vous etes deconnecte");

            }
        }
    }
}
