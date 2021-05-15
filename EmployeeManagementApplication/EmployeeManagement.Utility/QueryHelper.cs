using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Utility
{
    public class QueryHelper
    {
        public const string GetAllEmployees = @"SELECT FirstName, LastName, EmailAddress, DisplayName, UserName, DisplayUserGUID FROM TestV_Users;";
        public const string GetEmployee = @"SELECT FirstName, LastName, EmailAddress, DisplayName, UserName, DisplayUserGUID FROM TestV_Users WHERE DisplayUserGUID = @DisplayUserGUID;";
        public const string CreateEmployee = @"DECLARE @DisplayUserGUID UniqueIdentifier = NEWID();
                                            INSERT INTO TestV_Users (FirstName, LastName, EmailAddress, DisplayName, UserName, DisplayUserGUID)
                                            VALUES(@FirstName, @LastName, @EmailAddress, @DisplayName, @UserName, @DisplayUserGUID)
                                            SELECT 1 AS IsSuccess, CAST( @DisplayUserGUID AS NVARCHAR(MAX)) AS [Message]";
        public const string UpdateEmployee = @"UPDATE TestV_Users
                                            SET FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, DisplayName = @DisplayName, UserName = @UserName
                                            WHERE DisplayUserGUID = @DisplayUserGUID AND IsActive = 1;
                                            SELECT 1 AS IsSuccess, 'Updated' AS [Message]";
        public const string DeleteEmployee = @"UPDATE TestV_Users SET IsActive = 0 WHERE DisplayUserGUID = @DisplayUserGUID;
                                            SELECT 1 AS IsSuccess, 'Deleted' AS [Message]";
    }
}
