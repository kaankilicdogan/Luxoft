using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel.Repositories;
using EntityModel;

namespace ChatServerBusiness
{
    /// <summary>
    /// User business operations class.
    /// </summary>
    public class UserBusiness
    {
        /// <summary>
        /// Saves new user to db.
        /// </summary>
        /// <param name="nickname">New user nick name</param>
        /// <returns>New User informations.</returns>
        public static User SaveUser(string nickname)
        {
            return UserRepository.Save(nickname);
        }
    }
}
