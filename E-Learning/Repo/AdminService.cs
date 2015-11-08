using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Learning.Repo
{
    public class AdminService
    {
        public List<Admin> GetAllAdmins()
        {
            using (var context = new DB_ELearningEntities())
            {
                var list = context.Admins.ToList();
                return list;
            }
        }

        public void CreateAdmin(string email)
        {
            using (var context = new DB_ELearningEntities())
            {
                var newAdmin = context.Admins.Create();
                newAdmin.Email = email;

                context.Admins.Attach(newAdmin);
                context.SaveChanges();
            }
        }
    }
}