using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Contract
{
    public interface IDbResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

    }
}
