using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedWCFService
{
    /// <summary>
    /// Chat callback interface.
    /// </summary>
    public interface IChatCallback
    {
        /// <summary>
        /// Updates clients chat room list.
        /// </summary>
        /// <param name="chatRoomList">The current chat room list.</param>
        [OperationContract(IsOneWay = true)]
        void UpdateChatRooms(List<ChatRoom> chatRoomList);

        /// <summary>
        /// Sent related chat room clients latest messages.
        /// </summary>
        /// <param name="messageList">Last 30 message list.</param>
        [OperationContract(IsOneWay = true)]
        void LatestMessages(List<Message> messageList);

        /// <summary>
        /// Sent database user information to client.
        /// </summary>
        /// <param name="user">The user information.</param>
        [OperationContract(IsOneWay = true)]
        void UserInformation(User user);
    }
}
