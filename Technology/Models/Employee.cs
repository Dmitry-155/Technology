namespace Technology.WebPortal.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MidName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// Отдел
        /// </summary>
        public string Department { get; set; }
    }
}
