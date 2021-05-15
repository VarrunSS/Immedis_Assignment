using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Common
{
    public class Employee : IEmployee
    {
        public Employee()
        {
            LineManager = new Employee();
            Comments = new List<IComment>();
        }

        public int ID { get; set; }

        public int DisplayGUID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public DateTime DateOfJoining { get; set; }

        public double Salary { get; set; }

        public SalaryType SalaryType { get; set; }

        public string Department { get; set; }

        public IEmployee LineManager { get; set; }

        public string Address { get; set; }

        public List<IComment> Comments { get; set; }


    }
}
