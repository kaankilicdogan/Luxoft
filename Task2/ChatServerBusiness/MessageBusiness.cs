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
    /// Message business operations class.
    /// </summary>
    public class MessageBusiness
    {
        /// <summary>
        /// List Last 30 messages sent to given chat room.
        /// </summary>
        /// <param name="chatRoom">Chat Room.</param>
        /// <returns>List of messages.</returns>
        public static List<Message> ListLastThirtyMessages(string chatRoom)
        {
            return MessageRepository.ListLastThirtyMessages(chatRoom);
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
            return MessageRepository.SaveMessageAndListLastThirtyMessages(user, message, chatRoom);
        }
    }
}
