using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Utility
{
    public class QueryHelper
    {
        public const string GetAllEmployees = @"
            SELECT 
            E.ID, E.FullName, E.Title, E.DateOfJoining, E.Salary, E.SalaryType, E.Department, E.FullAddress, E.LineManagerID,
            M.ID, M.FullName, M.Title, M.DateOfJoining, M.Salary, M.SalaryType, M.Department, M.FullAddress, M.LineManagerID
            FROM TestV_Employees AS E
            LEFT JOIN TestV_Employees AS M
            ON (E.LineManagerID = M.ID)
            ";
        public const string GetEmployee = @"
            SELECT 
            E.ID, E.FullName, E.Title, E.DateOfJoining, E.Salary, E.SalaryType, E.Department, E.FullAddress, E.LineManagerID,
            M.ID, M.FullName, M.Title, M.DateOfJoining, M.Salary, M.SalaryType, M.Department, M.FullAddress, M.LineManagerID
            FROM TestV_Employees AS E
            LEFT JOIN TestV_Employees AS M
            ON (E.LineManagerID = M.ID)
            WHERE ID = @ID;";

        public const string CreateEmployee = @"
            DECLARE @DisplayUserGUID UniqueIdentifier = NEWID();
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
