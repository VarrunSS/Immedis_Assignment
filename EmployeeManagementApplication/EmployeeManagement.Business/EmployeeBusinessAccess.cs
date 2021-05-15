using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.Business.Contract;
using EmployeeManagement.DataAccess.Contract;
using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.ViewModel;
using EmployeeManagement.Service.ViewModel.Param;

namespace EmployeeManagement.Business
{
    public class EmployeeBusinessAccess : IEmployeeBusinessAccess
    {
        private readonly IEmployeeDataAccess dataAccess = null;

        public EmployeeBusinessAccess()
        {
        }

        public async Task<EmployeeViewModel> CreateEmployeeAsync(EmployeeViewModelParam param)
        {
            var resp = await dataAccess.CreateEmployeeAsync(param);
            if (resp.IsSuccess)
            {
                param.DisplayGUID = Guid.Parse(resp.Message);

                var result = await GetEmployeeAsync(param); // get employee details
                return result;
            }
            return null;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await dataAccess.GetAllEmployeeAsync();
        }

        public async Task<EmployeeViewModel> GetEmployeeAsync(EmployeeViewModelParam param)
        {
            return await dataAccess.GetEmployeeAsync(param);
        }

        public async Task<EmployeeViewModel> UpdateEmployeeAsync(EmployeeViewModelParam param)
        {
            var resp = await dataAccess.UpdateEmployeeAsync(param);
            if (resp.IsSuccess)
            {
                var result = await GetEmployeeAsync(param); // get employee details
                return result;
            }
            return null;
        }

        public async Task<EmployeeViewModel> DeleteEmployeeAsync(EmployeeViewModelParam param)
        {
            var resp = await dataAccess.DeleteEmployeeAsync(param);
            if (resp.IsSuccess)
            {
            }
            return null;
        }

    }
}
