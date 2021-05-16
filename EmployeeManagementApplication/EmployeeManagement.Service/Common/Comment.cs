using EmployeeManagement.Service.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Service.Common
{
    public class Comment : IComment
    {
        [Key]
        public int ID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }


    }
}
