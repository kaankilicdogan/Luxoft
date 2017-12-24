using ChatClient.ChatService;
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
using System.Windows.Shapes;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for ChatRoom.xaml
    /// </summary>
    public partial class ChatRoom : Page
    {
        ChatServiceCallbackClient client = null;
        string myNickname;
        User userInfo;
        ChatClient.ChatService.ChatRoom[] chatRoomList;

        public ChatRoom(string nickname)
        {
            InitializeComponent();
            this.SendNickname(nickname);
        }

        /// <summary>
        /// Send given nickname to service.
        /// </summary>
        /// <param name="nickname">The nickname information.</param>
        private void SendNickname(string nickname)
        {
            myNickname = nickname;
            client = new ChatServiceCallbackClient();
            client.SaveUser(client, nickname);
            client.UserInfo += new UserInformation(client_UserInformation_Event);
            client.UpdateChatRoom += new UpdateChatRooms(client_UpdateChatRoomInformation_Event);
        }

        /// <summary>
        /// The loged in user information event.
        /// </summary>
        /// <param name="user">The user information.</param>
        void client_UserInformation_Event(User user)
        {
            this.userInfo = user;
        }

        /// <summary>
        /// Chat room list updated event.
        /// </summary>
        /// <param name="chatRoomList">The latest chat room list.</param>
        void client_UpdateChatRoomInformation_Event(ChatClient.ChatService.ChatRoom[] chatRoomList)
        {
            this.chatRoomList = chatRoomList;
            chatRoomGrid.ItemsSource = this.chatRoomList;
        }

        /// <summary>
        /// Joins user to selected chat room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedChatRoom = (ChatClient.ChatService.ChatRoom)chatRoomGrid.SelectedItem;
            if (selectedChatRoom == null)
            {
                MessageBox.Show("Please select a Chat Room to join.");
                return;
            }

            NavigationService.Navigate(new Chat(client, userInfo, selectedChatRoom));
        }

        /// <summary>
        /// Creates chat room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var tempChatRoomName = newChatRoom.Text;
            if (tempChatRoomName.Length < 1)
            {
                MessageBox.Show("Please Enter a Chat Room Name.");
                return;
            }

            if (client == null)
            {
                client = new ChatServiceCallbackClient();
            }

            client.CreateChatRoom(tempChatRoomName);
        }
    }
}
