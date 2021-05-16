using EmployeeManagement.DataAccess.Contract;
using EmployeeManagement.Service.Common;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.ViewModel;
using EmployeeManagement.Service.ViewModel.Param;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class MockEmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly ILogger<MockEmployeeDataAccess> _logger;
        private readonly ApiContext _context;

        public MockEmployeeDataAccess(ILogger<MockEmployeeDataAccess> logger,
            ApiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeViewModel> GetEmployeeAsync(EmployeeViewModelParam param)
        {
            var result = new EmployeeViewModel(param);
            var data = await _context.Employees.Where(v => v.ID == param.ID).FirstOrDefaultAsync();
            result.MapData(data);
            return result;
        }

        public async Task<IDbResponse> CreateEmployeeAsync(EmployeeViewModelParam param)
        {
            await _context.Employees.AddAsync(param);
            var data = await _context.SaveChangesAsync();

            IDbResponse result = new DbResponse(true);
            if (data == 0)
                result = new DbResponse(false, "Failed");
            return result;
        }

        public async Task<IDbResponse> UpdateEmployeeAsync(EmployeeViewModelParam param)
        {
            IDbResponse result = new DbResponse(true);

            _context.Entry(await _context.Employees.FirstOrDefaultAsync(x => x.ID == param.ID)).CurrentValues.SetValues(param.FormatData());
            var resp = await _context.SaveChangesAsync();
            
            if(resp == 0) result = new DbResponse(false, "Update failed");
            return result;
            //var newEmp = await _context.Employees.Where(v => v.ID == param.ID).FirstOrDefaultAsync();
            //if (newEmp != null)
            //{
            //    newEmp = param.FormatData();
            //    await _context.SaveChangesAsync();
            //}
            //else result = new DbResponse(false, "Not found");
            //return result;
        }

        public async Task<IDbResponse> DeleteEmployeeAsync(EmployeeViewModelParam param)
        {
            IDbResponse result = new DbResponse();
            _context.Entry(param).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return result;
        }

    }
}
