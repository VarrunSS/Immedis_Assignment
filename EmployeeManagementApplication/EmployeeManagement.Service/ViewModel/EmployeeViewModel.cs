using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.ViewModel.Param;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

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
            ID = param.ID;
            IsSuccess = true;
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }



        // dropdowns
        [NotMapped]
        public List<SelectListItem> SalaryTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Monthly", Text = "Monthly" },
            new SelectListItem { Value = "Yearly", Text = "Yearly" },
        };

        [NotMapped]
        public List<SelectListItem> Departments { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Dept 1", Text = "Department 1" },
            new SelectListItem { Value = "Dept 2", Text = "Department 2" },
            new SelectListItem { Value = "Dept 3", Text = "Department 3" },
            new SelectListItem { Value = "Dept 4", Text = "Department 4" },
        };

        [NotMapped]
        public List<SelectListItem> LineManagerIDs { get; set; }

        
    }
}
