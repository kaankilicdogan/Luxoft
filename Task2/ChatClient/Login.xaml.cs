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

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Logs user in to the chat system.
        /// </summary>
        /// <param name="sender">The sender information.</param>
        /// <param name="e">The routed evet arguments.</param>
        private void Proceed_Click(object sender, RoutedEventArgs e)
        {
            var nicknameString = txtNickname.Text;
            if (nicknameString.Length < 1)
            {
                MessageBox.Show("Please Enter a Nickname.");
                return;
            }

            NavigationService.Navigate(new ChatRoom(nicknameString));
        }
    }
}
