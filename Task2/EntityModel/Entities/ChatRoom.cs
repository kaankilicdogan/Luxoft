using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    /// <summary>
    /// Chat Room Object.
    /// </summary>
    public class ChatRoom
    {
        /// <summary>
        /// ChatRoom Id.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Chat room name.
        /// </summary>
        public string Name { get; set; }
    }
}
