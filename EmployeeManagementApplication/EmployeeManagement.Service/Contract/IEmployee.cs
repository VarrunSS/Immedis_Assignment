using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Contract
{
    public interface IEmployee
    {
        int ID { get; set; }

        string FullName { get; set; }

        string Title { get; set; }

        DateTime DateOfJoining { get; set; }

        double Salary { get; set; }

        string SalaryType { get; set; }

        string Department { get; set; }

        //Employee LineManager { get; set; }
        public int LineManagerID { get; set; }

        string Address { get; set; }

        List<Comment> Comments { get; set; }

    }


}
