using E_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Learning.Repo
{
    public class UserServices
    {
        public UserProfile GetUserByUserID(int userID)
        {
            using (var context = new UsersContext())
            {
                var userProfile = context.UserProfiles.Where(user => user.UserId == userID).FirstOrDefault();
                if (userProfile != null)
                    return userProfile;
                else throw new Exception("No user with this id was found");
            }
        }
    }
}