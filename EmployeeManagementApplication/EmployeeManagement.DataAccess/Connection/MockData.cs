using EmployeeManagement.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DataAccess.Connection
{
    public static class MockData
    {
        public static void AddTestData(ApiContext context)
        {

            for (int ind = 1; ind <= 100; ind++)
            {
                var testUser = new Employee
                {
                    ID = ind,
                    FullName = $"Employee {ind}",
                    Title = $"SDE {ind % 10}",
                    DateOfJoining = new DateTime(2020, 01, 01).AddDays(ind),
                    Salary = Math.Round(new Random().NextDouble() * 10000, 2),
                    SalaryType = "Monthly",
                    Department = $"Department {ind}",
                    LineManagerID = ind - 1,
                    Address = $"Address {ind}",
                };

                context.Employees.Add(testUser);
            }

            for (int ind = 1; ind <= 300; ind++)
            {
                var testPost = new Comment
                {
                    ID = ind,
                    EmployeeID = ind % 100,
                    Author = $"Author {ind}",
                    Content = $"Content {ind}",
                    CreatedOn = new DateTime(2020, 01, 01).AddDays(ind),
                };

                context.Comments.Add(testPost);
            }

            context.SaveChanges();
        }
    
    }
}
