using EmployeeManagement.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Common
{
    public class DbResponse : IDbResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
