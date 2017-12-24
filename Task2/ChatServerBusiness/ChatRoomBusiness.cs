using EntityModel;
using EntityModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerBusiness
{
    /// <summary>
    /// Chat room business operations class.
    /// </summary>
    public class ChatRoomBusiness
    {
        /// <summary>
        /// Lists all recorded chat rooms.
        /// </summary>
        /// <returns>Chat room list.</returns>
        public static List<ChatRoom> ListChatRooms()
        {
            return ChatRoomRepository.ListChatRooms();
        }

        /// <summary>
        /// Saves given chat room and returns latest chat room list.
        /// </summary>
        /// <param name="chatRoomName">Chat room name.</param>
        /// <returns>Latest chat room list.</returns>
        public static List<ChatRoom> SaveAndGetLatestChatRoomList(string chatRoomName)
        {
            return ChatRoomRepository.SaveAndGetLatestChatRoomList(chatRoomName);
        }
    }
}
