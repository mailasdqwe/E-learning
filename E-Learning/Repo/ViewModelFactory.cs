using E_Learning.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Learning.Repo
{
    public static class ViewModelFactory
    {
        private static readonly UserServices userServices = new UserServices();
        /// <summary>
        /// Gets the student view model from student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns>E_Learning.Models.ViewModels.StudentViewModel.</returns>
        public static StudentViewModel GetStudentViewModelFromStudent(Student student){
            StudentViewModel studentVM = new StudentViewModel();
            studentVM.Address = studentVM.Address;
            studentVM.CardNo = student.CardNO;
            studentVM.FullName = student.FirstName + " " + student.LastName;
            studentVM.IsBlocked = student.isBlocked;
            studentVM.StudentID = student.StudentID;
            var correspondingUserProfile = userServices.GetUserByUserID((int)student.UserID);
            studentVM.Username = correspondingUserProfile.UserName;

            return studentVM;
        }
    }
}