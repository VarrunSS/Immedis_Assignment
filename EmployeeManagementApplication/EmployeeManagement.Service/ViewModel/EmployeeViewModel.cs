using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.ViewModel.Param;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.ViewModel
{
    public class EmployeeViewModel : EmployeeViewModelParam, IDbResponse
    {
        public EmployeeViewModel() : base()
        {
        }

        public EmployeeViewModel(EmployeeViewModelParam param) : this()
        {
            LoginUserID = param.LoginUserID;
            DisplayGUID = param.DisplayGUID;
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

    }
}
