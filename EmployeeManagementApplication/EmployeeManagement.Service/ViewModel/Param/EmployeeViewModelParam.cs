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

        public object ExposeCreateEmployee() => new
        {
            Name,
            //LastName,
            //EmailAddress,
            //DisplayName,
            //UserName
        };
        public object ExposeUpdateEmployee() => new
        {
            DisplayGUID,
            //FirstName,
            //LastName,
            //EmailAddress,
            //DisplayName,
            //UserName
        };
        public object ExposeDeleteEmployee() => new { DisplayGUID };
        public object ExposeGetEmployee() => new { DisplayGUID };
    }
}
