using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EmployeeManagement.DataAccess.Contract;
using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.ViewModel;
using EmployeeManagement.Service.ViewModel.Param;
using EmployeeManagement.Utility;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.DataAccess
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly ILogger<EmployeeDataAccess> _logger;

        public EmployeeDataAccess(ILogger<EmployeeDataAccess> logger)
        {
            _logger = logger;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var result = new List<Employee>();

            try
            {
                using var conn = ConnectionHelper.GetDbContext();
                result = (await conn.QueryAsync<Employee, Employee, Employee>(
                    QueryHelper.GetAllEmployees,
                    (employee, manager) =>
                    {
                        //employee.LineManager = manager;
                        return employee;
                    },
                    splitOn: "ID")
                    ).Distinct().AsList();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error occured. Message: {ex.Message}");
            }
            finally
            {

            }
            return result;
        }

        public async Task<EmployeeViewModel> GetEmployeeAsync(EmployeeViewModelParam param)
        {
            var result = new EmployeeViewModel(param);
            try
            {
                using (var conn = ConnectionHelper.GetDbContext())
                    result = await conn.QueryFirstAsync<EmployeeViewModel>(QueryHelper.GetEmployee, param.ExposeGetEmployee());
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error occured. Message: {ex.Message}");
            }
            finally
            {

            }
            return result;
        }

        public async Task<IDbResponse> CreateEmployeeAsync(EmployeeViewModelParam param)
        {
            IDbResponse result = new DbResponse();

            try
            {
                using (var conn = ConnectionHelper.GetDbContext())
                {
                    result = await conn.QueryFirstAsync<DbResponse>(QueryHelper.CreateEmployee, param.ExposeCreateEmployee());
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error occured. Message: {ex.Message}");
            }
            finally
            {

            }
            return result;
        }

        public async Task<IDbResponse> UpdateEmployeeAsync(EmployeeViewModelParam param)
        {
            IDbResponse result = new DbResponse();

            try
            {
                using (var conn = ConnectionHelper.GetDbContext())
                {
                    result = await conn.QueryFirstAsync<DbResponse>(QueryHelper.UpdateEmployee, param.ExposeUpdateEmployee());
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error occured. Message: {ex.Message}");
            }
            finally
            {

            }
            return result;
        }

        public async Task<IDbResponse> DeleteEmployeeAsync(EmployeeViewModelParam param)
        {
            IDbResponse result = new DbResponse();

            try
            {
                using (var conn = ConnectionHelper.GetDbContext())
                {
                    result = await conn.QueryFirstAsync<DbResponse>(QueryHelper.DeleteEmployee, param.ExposeDeleteEmployee());
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error occured. Message: {ex.Message}");
            }
            finally
            {

            }
            return result;
        }

    }
}
