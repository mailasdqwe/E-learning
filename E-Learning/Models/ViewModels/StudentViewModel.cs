using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Learning.Models.ViewModels
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string CardNo { get; set; }
        public bool? IsBlocked { get; set; }
    }
}