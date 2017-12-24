using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public delegate void UpdateChatRooms(ChatClient.ChatService.ChatRoom[] chatRoomList);
    public delegate void LatestMessages(ChatClient.ChatService.Message[] messageList);
    public delegate void UserInformation(ChatClient.ChatService.User user);

    public class ChatServiceCallbackClient : ChatService.IChatServiceCallback
    {
        public event UpdateChatRooms UpdateChatRoom;
        public event LatestMessages LatestMessageList;
        public event UserInformation UserInfo;

        InstanceContext inst = null;
        ChatService.ChatServiceClient chatClient = null;

        /// <summary>
        /// Call Save User method.
        /// </summary>
        /// <param name="client">The client instance of ChatService.</param>
        /// <param name="nickname">The nickname information.</param>
        public void SaveUser(ChatServiceCallbackClient client, string nickname)
        {
            inst = new InstanceContext(client);
            chatClient = new ChatService.ChatServiceClient(inst);
            chatClient.SaveUser(nickname);
        }

        /// <summary>
        /// Creates users chat room.
        /// </summary>
        /// <param name="chatRoomName">The Chat room name.</param>
        public void CreateChatRoom(string chatRoomName)
        {
            chatClient.SaveChatRoom(chatRoomName);
        }

        /// <summary>
        /// Sents new message to given chat room.
        /// </summary>
        /// <param name="user">User name.</param>
        /// <param name="message">The message.</param>
        /// <param name="chatRoom">The chat room.</param>
        public void SentMessage(string user, string message, string chatRoom)
        {
            chatClient.SentMessage(user, message, chatRoom);
        }

        /// <summary>
        /// User try to join selected chat room.
        /// </summary>
        /// <param name="user">The user information.</param>
        /// <param name="chatRoom">The chat room information.</param>
        public void JoinChatRoom(string user, string chatRoom)
        {
            chatClient.JoinChatRoom(user, chatRoom);
        }

        /// <summary>
        /// User info callback method.
        /// </summary>
        /// <param name="user">The user information.</param>
        public void UserInformation(ChatClient.ChatService.User user)
        {
            if (UserInfo != null)
            {
                //raise event.
                UserInfo(user);
            }
        }

        /// <summary>
        /// Latest Messages recieved.
        /// </summary>
        /// <param name="messageList">Latest 30 message list.</param>
        public void LatestMessages(ChatClient.ChatService.Message[] messageList)
        {
            if (LatestMessageList != null)
            {
                // raise event.
                LatestMessageList(messageList);
            }
        }

        /// <summary>
        /// Latest chat room list recieved.
        /// </summary>
        /// <param name="chatRoomList">Latest chat room list.</param>
        public void UpdateChatRooms(ChatClient.ChatService.ChatRoom[] chatRoomList)
        {
            if (UpdateChatRoom != null)
            {
                //raise event.
                UpdateChatRoom(chatRoomList);
            }
        }
    }
}
