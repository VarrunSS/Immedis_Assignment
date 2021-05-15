using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.ViewModel;
using EmployeeManagement.Service.ViewModel.Param;

namespace EmployeeManagement.Business.Contract
{
    public interface IEmployeeBusinessAccess
    {
        Task<List<Employee>> GetAllEmployeeAsync();

        Task<EmployeeViewModel> GetEmployeeAsync(EmployeeViewModelParam param);

        Task<EmployeeViewModel> CreateEmployeeAsync(EmployeeViewModelParam param);

        Task<EmployeeViewModel> UpdateEmployeeAsync(EmployeeViewModelParam param);

        Task<EmployeeViewModel> DeleteEmployeeAsync(EmployeeViewModelParam param);
    }
}
