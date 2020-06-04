using System.Collections.Generic;

namespace Technology.WebPortal.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
    }
}
