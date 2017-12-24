using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SelfHostedWCFService
{
    /// <summary>
    /// The Chat Service interface.
    /// </summary>
    [ServiceContract(CallbackContract = typeof (IChatCallback))]
    public interface IChatService
    {
        /// <summary>
        /// Saves given nickname to users table.
        /// </summary>
        /// <param name="nickname">The nickname information.</param>
        [OperationContract(IsOneWay = true)]
        void SaveUser(string nickname);        

        /// <summary>
        /// Saves chat room to chat room list.
        /// </summary>
        /// <param name="chatRoomName">New chat room.</param>
        [OperationContract(IsOneWay = true)]
        void SaveChatRoom(string chatRoomName);

        /// <summary>
        /// Joins user to given chat room.
        /// </summary>
        /// <param name="user">The user information.</param>
        /// <param name="chatRoom">The chat room information.</param>
        [OperationContract(IsOneWay = true)]
        void JoinChatRoom(string user, string chatRoom);

        /// <summary>
        /// Saves new message to db.
        /// </summary>
        /// <param name="user">The user information.</param>
        /// <param name="message">The message text.</param>
        /// <param name="chatRoom">The chat room information.</param>
        [OperationContract(IsOneWay = true)]
        void SentMessage(string user, string message, string chatRoom);
    }
}
