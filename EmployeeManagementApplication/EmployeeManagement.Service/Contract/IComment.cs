using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Contract
{
    public interface IComment
    {
        DateTime CreatedOn { get; set; }

        string Author { get; set; }

        string Content { get; set; }

    }
}
