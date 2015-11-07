using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Learning.Repo
{
    public class StudentService
    {

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>List&lt;Student&gt;.</returns>
        public List<Student> GetAllStudents()
        {
            using (var context = new DB_ELearningEntities())
            {
                var list = context.Students.ToList();
                return list;
            }
        }

        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="studentID">The student identifier.</param>
        /// <exception cref="NullReferenceException">Student with this id not found!</exception>
        public void DeleteStudent(int studentID)
        {
            using (var context = new DB_ELearningEntities())
            {
                var studentToDelete = context.Students.Where(student => student.StudentID == studentID).FirstOrDefault();
                if (studentToDelete != null)
                {
                    context.Students.Remove(studentToDelete); 
                    context.SaveChanges();
                }
                else throw new NullReferenceException("Student with this id not found!");
            }
        }


        /// <summary>
        /// Adds the student.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <param name="email">The email.</param>
        /// <param name="cardNO">The card number.</param>
        public void AddStudent(int userID, string firstName, string lastName, string address, string email, string cardNO)
        {
            using (var context = new DB_ELearningEntities())
            {
                var newStudent = context.Students.Create();
                newStudent.Address = address;
                newStudent.CardNO = cardNO;
                newStudent.Email = email;
                newStudent.FirstName = firstName;
                newStudent.isBlocked = false;
                newStudent.LastName = lastName;
                newStudent.UserID = userID;

                context.Students.Attach(newStudent);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Blocks/Unblocks the student with the given student id.
        /// </summary>
        /// <param name="studentID">The student identifier.</param>
        /// <exception cref="NullReferenceException">Student with this id not found!</exception>
        public void ToggleBlock(int studentID)
        {
            using (var context = new DB_ELearningEntities())
            {
                var studentToBlock = context.Students.Where(student => student.StudentID == studentID).FirstOrDefault();
                if (studentToBlock != null)
                {
                    if (studentToBlock.isBlocked == null || studentToBlock.isBlocked == false)
                        studentToBlock.isBlocked = true;
                    else 
                        studentToBlock.isBlocked = false;
                    context.SaveChanges();
                }
                else throw new NullReferenceException("Student with this id not found!");
            }
        }

    }

}