using EmployeeManagement.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Common
{
    public class DbResponse : IDbResponse
    {
        public DbResponse()
        {
            IsSuccess = false;
            Message = string.Empty;
        }
        public DbResponse(bool isSuccess) : this()
        {
            IsSuccess = isSuccess;
        }
        public DbResponse(bool isSuccess, string message) : this()
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
