using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.Business.Contract;
using EmployeeManagement.DataAccess.Contract;
using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.ViewModel;
using EmployeeManagement.Service.ViewModel.Param;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Business
{
    public class EmployeeBusinessAccess : IEmployeeBusinessAccess
    {
        private readonly ILogger<EmployeeBusinessAccess> _logger;
        private readonly IEmployeeDataAccess _dataAccess = null;

        public EmployeeBusinessAccess(ILogger<EmployeeBusinessAccess> logger,
            IEmployeeDataAccess dataAccess
        )
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public async Task<EmployeeViewModel> CreateEmployeeAsync(EmployeeViewModelParam param)
        {
            var resp = await _dataAccess.CreateEmployeeAsync(param);
            if (resp.IsSuccess)
            {
                param.ID = Int32.Parse(resp.Message);

                var result = await GetEmployeeAsync(param); // get employee details
                return result;
            }
            return null;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _dataAccess.GetAllEmployeeAsync();
        }

        public async Task<EmployeeViewModel> GetEmployeeAsync(EmployeeViewModelParam param)
        {
            return await _dataAccess.GetEmployeeAsync(param);
        }

        public async Task<EmployeeViewModel> UpdateEmployeeAsync(EmployeeViewModelParam param)
        {
            var resp = await _dataAccess.UpdateEmployeeAsync(param);
            if (resp.IsSuccess)
            {
                var result = await GetEmployeeAsync(param); // get employee details
                return result;
            }
            return null;
        }

        public async Task<EmployeeViewModel> DeleteEmployeeAsync(EmployeeViewModelParam param)
        {
            var resp = await _dataAccess.DeleteEmployeeAsync(param);
            if (resp.IsSuccess)
            {
                var result = new EmployeeViewModel(param);
                return result;
            }
            return null;
        }

    }
}
