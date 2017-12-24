using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    /// <summary>
    /// Chat User Object.
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nickname property.
        /// </summary>
        public string Nickname { get; set; }
    }
}
