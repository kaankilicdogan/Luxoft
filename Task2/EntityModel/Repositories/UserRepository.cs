using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Repositories
{
    /// <summary>
    /// User Repository class.
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// Saves given user to db.
        /// </summary>
        /// <param name="nickname">New user nickname.</param>
        /// <returns>New user object.</returns>
        public static User Save(string nickname)
        {
            using (var db = new LiteRepository(@"MyData.db"))
            {
                User newUser = new User { Id = System.Guid.NewGuid(), Nickname = nickname };
                db.Insert<User>(newUser);
                return newUser;
            }
        }
    }
}
