namespace Technology.WebPortal.Models
{
    /// <summary>
    /// Обращение
    /// </summary>
    public class Issue
    {
        /// <summary>
        /// Идентификатор обращения
        /// </summary>
        public int IssueID { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Описание проблемы
        /// </summary>
        public int Description { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int EmployerID { get; set; }

        /// <summary>
        /// Ссылка на сотрудника
        /// </summary>
        public virtual Employee Employer { get; set; }
    }
}
