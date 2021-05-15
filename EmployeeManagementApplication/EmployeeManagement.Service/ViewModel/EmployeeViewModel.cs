using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.ViewModel
{
    public class EmployeeViewModel : Employee, IDbResponse
    {
        public EmployeeViewModel() : base()
        {
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

    }
}
