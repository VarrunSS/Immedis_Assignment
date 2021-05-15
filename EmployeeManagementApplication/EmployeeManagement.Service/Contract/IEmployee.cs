using EmployeeManagement.Service.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Contract
{
    public interface IEmployee
    {
        int ID { get; set; }

        Guid DisplayGUID { get; set; }

        string Name { get; set; }

        string Title { get; set; }

        DateTime DateOfJoining { get; set; }

        double Salary { get; set; }

        SalaryType SalaryType { get; set; }

        string Department { get; set; }

        IEmployee LineManager { get; set; }

        string Address { get; set; }

        List<IComment> Comments { get; set; }

    }


}
