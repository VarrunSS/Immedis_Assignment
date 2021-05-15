using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.ViewModel.Param
{
    public class CommentViewModelParam : Comment, ILoginUser
    {
        public CommentViewModelParam() : base()
        {
        }

        public string LoginUserID { get; set; }
    }
}
