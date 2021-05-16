using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Service.Common
{
    public class Employee : IEmployee
    {
        public Employee()
        {
            //LineManager = new Employee();
            //Comments = new List<Comment>();
        }

        [Key]
        public int ID { get; set; }

        public string FullName { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }

        public double Salary { get; set; }

        public string SalaryType { get; set; }

        public string Department { get; set; }

        //public Employee LineManager { get; set; }
        public int LineManagerID { get; set; }

        public string Address { get; set; }

        public List<Comment> Comments { get; set; }



    }
}
