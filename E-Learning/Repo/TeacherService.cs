using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Learning.Repo
{
    public class TeacherService
    {
        public List<Teacher> GetAllTeachers()
        {
            using (var context = new DB_ELearningEntities())
            {
                var list = context.Teachers.ToList();
                return list;
            }
        }

        public Teacher GetByID(int teacherID)
        {
            using (var context = new DB_ELearningEntities())
            {
                var prof = context.Teachers.Where(teacher => teacher.TeacherID == teacherID).First();
                if (prof == null)
                    throw new Exception("No teacher with given ID found!");
                else return prof;
            }
        }

        public void CreateTeacher(string firstName, string LastName, string email)
        {
            using (var context = new DB_ELearningEntities())
            {
                var newTeacher = context.Teachers.Create();
                newTeacher.FirstName = firstName;
                newTeacher.LastName = LastName;
                newTeacher.Email = email;

                context.Teachers.Attach(newTeacher);
                context.SaveChanges();
            }
        }

        public void EditTeacher(int teacherID, string firstName, string LastName, string email)
        {
            using (var context = new DB_ELearningEntities())
            {
                var prof = context.Teachers.Where(teacher => teacher.TeacherID == teacherID).First();
                prof.FirstName = firstName;
                prof.LastName = LastName;
                prof.Email = email;

                context.SaveChanges();
            }
        }

        public void DeleteTeacher(int teacherID)
        {
            using (var context = new DB_ELearningEntities())
            {
                var prof = context.Teachers.Where(teacher => teacher.TeacherID == teacherID).First();
                if (prof == null)
                    throw new Exception("Teacher with given ID not found!");
                else
                {
                    context.Teachers.Remove(prof);
                    context.SaveChanges();
                }
            }
        }
    }
}