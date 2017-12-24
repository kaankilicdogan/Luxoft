using ChatServerBusiness;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SelfHostedWCFService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        Dictionary<string, IChatCallback> allUsers = new Dictionary<string, IChatCallback>();
        Dictionary<string, List<string>> chatRoomUsers = new Dictionary<string, List<string>>();
        IChatCallback callback = null;
        
        /// <summary>
        /// Saves new user.
        /// </summary>
        /// <param name="nickname">New user nickname.</param>
        /// <returns>User information object.</returns>
        public void SaveUser(string nickname)
        {
            var user = UserBusiness.SaveUser(nickname);
            callback = OperationContext.Current.GetCallbackChannel<IChatCallback>();
            allUsers.Add(user.Id + user.Nickname, callback);
            callback.UserInformation(user);
            callback.UpdateChatRooms(ChatRoomBusiness.ListChatRooms());
        }

        /// <summary>
        /// Saves given chat room to db and rise callback to updated chat room list.
        /// </summary>
        /// <param name="chatRoomName">Chat room name.</param>
        public void SaveChatRoom(string chatRoomName)
        {
            var chatRoomList = ChatRoomBusiness.SaveAndGetLatestChatRoomList(chatRoomName);

            foreach (KeyValuePair<string, IChatCallback> user in allUsers)
            {
                IChatCallback proxy = user.Value;
                proxy.UpdateChatRooms(chatRoomList);
            }
        }

        /// <summary>
        /// Add user to given chat room and send latest 30 messages to this user.
        /// </summary>
        /// <param name="user">User information.</param>
        /// <param name="chatRoom">Chat room information.</param>
        public void JoinChatRoom(string user, string chatRoom)
        {
            //Add user to chat room.
            if (chatRoomUsers.ContainsKey(chatRoom))
            {
                var userList = chatRoomUsers[chatRoom];
                userList.Add(user);
                chatRoomUsers[chatRoom] = userList;
            }
            else
            {
                // Chat rooms first user.
                List<string> userList = new List<String>();
                userList.Add(user);
                chatRoomUsers.Add(chatRoom, userList);
            }

            // send previous messages to user.
            if (allUsers.ContainsKey(user))
            {
                IChatCallback proxy = allUsers[user];
                proxy.LatestMessages(MessageBusiness.ListLastThirtyMessages(chatRoom));
            }
        }

        /// <summary>
        /// Saves new message and sent latest 30 messages to all chat room users.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <param name="chatRoom"></param>
        public void SentMessage(string user, string message, string chatRoom)
        {
            var messageList = MessageBusiness.SaveMessageAndListLastThirtyMessages(user, message, chatRoom);
            if (chatRoomUsers.ContainsKey(chatRoom))
            {
                var userList = chatRoomUsers[chatRoom];
                foreach(string tempUser in userList)
                {
                    // send previous messages to user.
                    if (allUsers.ContainsKey(tempUser))
                    {
                        IChatCallback proxy = allUsers[tempUser];
                        proxy.LatestMessages(messageList);
                    }
                }
            }
        }
    }
}
