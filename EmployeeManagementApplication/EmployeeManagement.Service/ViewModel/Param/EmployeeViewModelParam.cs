using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.ViewModel.Param
{
    public class EmployeeViewModelParam : Employee, ILoginUser
    {
        public EmployeeViewModelParam() : base()
        {
        }

        public string LoginUserID { get; set; }

        public Employee FormatData()
        {
            return new Employee {
                ID = ID,
                FullName = FullName,
                Title = Title,
                DateOfJoining = DateOfJoining,
                Salary = Salary,
                SalaryType = SalaryType,
                Department = Department,
                LineManagerID = LineManagerID,
                Address = Address,
                Comments = Comments,
            };
        }

        // map data
        public void MapData(Employee data)
        {
            FullName = data.FullName;
            Title = data.Title;
            DateOfJoining = data.DateOfJoining;
            Salary = data.Salary;
            SalaryType = data.SalaryType;
            Department = data.Department;
            LineManagerID = data.LineManagerID;
            Address = data.Address;
            Comments = data.Comments;
        }

        public object ExposeCreateEmployee() => new
        {
            FullName,
            //Title,
            //DateOfJoining,
            //Salary,
            //...
        };
        public object ExposeUpdateEmployee() => new
        {
            ID,
            //FullName,
            //Title,
            //DateOfJoining,
            //Salary,
            //...
        };
        public object ExposeDeleteEmployee() => new { ID };
        public object ExposeGetEmployee() => new { ID };
    }
}
