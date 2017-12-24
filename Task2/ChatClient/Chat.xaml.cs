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
using ChatClient.ChatService;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Page
    {
        ChatServiceCallbackClient client = null;        
        ChatClient.ChatService.User userInfo = null;
        ChatClient.ChatService.ChatRoom chatRoom =null;
        public Chat(ChatServiceCallbackClient client, ChatClient.ChatService.User userInfo, ChatClient.ChatService.ChatRoom chatRoom)
        {
            InitializeComponent();
            this.client = client;
            this.userInfo = userInfo;
            this.chatRoom = chatRoom;
            header.Content = chatRoom.Name + " Chat Room";
            client.JoinChatRoom(userInfo.Id + userInfo.Nickname, chatRoom.Id + chatRoom.Name);
            client.LatestMessageList += new LatestMessages(client_LatestMessages_Event);
        }

        /// <summary>
        /// Latest message recieved event.
        /// </summary>
        /// <param name="messageList">Latest 30 message list.</param>
        public void client_LatestMessages_Event(Message[] messageList)
        {
            messageHistory.Text = "";
            foreach(Message message in messageList)
            {
                messageHistory.Text += string.Format(message.Sender + " ( " + message.SentTime.ToString() + " ) -> " + message.MessageText + " \n");
            }
        }

        /// <summary>
        /// Sent given message to chat room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tempMessage = newMessage.Text;
            if (tempMessage.Length < 1)
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            client.SentMessage(this.userInfo.Nickname, tempMessage, this.chatRoom.Id + this.chatRoom.Name);
            newMessage.Text = "";
        }

        /// <summary>
        /// Sents user to previous screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
