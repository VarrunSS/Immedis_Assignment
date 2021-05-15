using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.ViewModel
{
    public class CommentViewModel : Comment, IDbResponse
    {
        public CommentViewModel() : base()
        {
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

    }
}
