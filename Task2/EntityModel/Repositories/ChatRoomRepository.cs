using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Repositories
{
    /// <summary>
    /// Chat room object repository operations class.
    /// </summary>
    public class ChatRoomRepository
    {
        /// <summary>
        /// Gets recorded chat rooms.
        /// </summary>
        /// <returns>Chat room list.</returns>
        public static List<ChatRoom> ListChatRooms()
        {
            using (var db = new LiteRepository(@"MyData.db"))
            {
                return db.Query<ChatRoom>().ToList();
            }
        }

        /// <summary>
        /// Saves given chat room and returns latest chat room list.
        /// </summary>
        /// <param name="chatRoomName">Chat room name.</param>
        /// <returns>Latest chat room list.</returns>
        public static List<ChatRoom> SaveAndGetLatestChatRoomList(string chatRoomName)
        {
            using (var db = new LiteRepository(@"MyData.db"))
            {
                ChatRoom newChatRoom = new ChatRoom { Id = System.Guid.NewGuid(), Name = chatRoomName };
                db.Insert<ChatRoom>(newChatRoom);
                return db.Query<ChatRoom>().ToList();
            }
        }
    }
}
