using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EmployeeManagement.DataAccess.Contract;
using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.ViewModel;
using EmployeeManagement.Service.ViewModel.Param;
using EmployeeManagement.Utility;

namespace EmployeeManagement.DataAccess
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var result = new List<Employee>();

            try
            {
                using (var conn = ConnectionHelper.GetDbContext())
                    result = (await conn.QueryAsync<Employee>(QueryHelper.GetAllEmployees)).AsList();
            }
            catch (Exception ex)
            {

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

            }
            finally
            {

            }
            return result;
        }


    }
}
