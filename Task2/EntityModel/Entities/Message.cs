using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    /// <summary>
    /// Chat Message object.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Message Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Chat Message text.
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Message Sender.
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Chat room property.
        /// </summary>
        public string ChatRoom { get; set; }

        /// <summary>
        /// Message sent time.
        /// </summary>
        public DateTime SentTime { get; set; }
    }
}
