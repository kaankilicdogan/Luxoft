using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Repositories
{
    /// <summary>
    /// Message object repository operations class.
    /// </summary>
    public class MessageRepository
    {
        /// <summary>
        /// List Last 30 messages sent to given chat room.
        /// </summary>
        /// <param name="chatRoom">Chat Room.</param>
        /// <returns>List of messages.</returns>
        public static List<Message> ListLastThirtyMessages(string chatRoom)
        {
            using (var db = new LiteRepository(@"MyData.db"))
            {
                db.Database.GetCollection<Message>().EnsureIndex("ChatRoom");
                var messages = db.Query<Message>().Where(x => x.ChatRoom == chatRoom).ToList();

                return messages.OrderByDescending(x => x.SentTime).Take(30).ToList();
            }
        }

        /// <summary>
        /// Saves new message and List Last 30 messages sent to given chat room.
        /// </summary>
        /// <param name="user">User name.</param>
        /// <param name="message">Message information.</param>
        /// <param name="chatRoom">Chat room.</param>
        /// <returns></returns>
        public static List<Message> SaveMessageAndListLastThirtyMessages(string user, string message, string chatRoom)
        {
            using (var db = new LiteRepository(@"MyData.db"))
            {
                Message newMessage = new Message { Id = System.Guid.NewGuid(), MessageText = message, Sender = user, ChatRoom = chatRoom, SentTime = DateTime.Now };
                db.Insert<Message>(newMessage);
                db.Database.GetCollection<Message>().EnsureIndex("ChatRoom");
                var messages = db.Query<Message>().Where(x => x.ChatRoom == chatRoom).ToList();

                return messages.OrderByDescending(x => x.SentTime).Take(30).ToList();
            }
        }
    }
}
