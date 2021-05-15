using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.ViewModel;
using EmployeeManagement.Service.ViewModel.Param;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Contract
{
    public interface IEmployeeDataAccess
    {
        Task<List<Employee>> GetAllEmployeeAsync();

        Task<EmployeeViewModel> GetEmployeeAsync(EmployeeViewModelParam param);

        Task<IDbResponse> CreateEmployeeAsync(EmployeeViewModelParam param);

        Task<IDbResponse> UpdateEmployeeAsync(EmployeeViewModelParam param);

        Task<IDbResponse> DeleteEmployeeAsync(EmployeeViewModelParam param);

    }
}
