using EmployeeManagement.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Common
{
    public class Comment : IComment
    {
        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

    }
}
