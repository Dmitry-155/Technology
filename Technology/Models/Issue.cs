using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Number { get; set; }

        /// <summary>
        /// Описание проблемы
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Внешний ключ сотрудника
        /// </summary>
        [ForeignKey("Employer")]
        public int EmployerID { get; set; }

        /// <summary>
        /// Ссылка на сотрудника
        /// </summary>
        public virtual Employee Employer { get; set; }

        /// <summary>
        /// Внешний ключ категории обращения
        /// </summary>
        public int IssueCategoryID { get; set; }

        /// <summary>
        /// Ссылка на тип обращения
        /// </summary>
        [ForeignKey("IssueCategoryID")]
        public virtual IssueCategory IssueCategory { get; set; }

        /// <summary>
        /// Ссылка на тип комментарии
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
