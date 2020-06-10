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
        public int AuthorID { get; set; }

        /// <summary>
        /// Ссылка на сотрудника-автора
        /// </summary>
        [ForeignKey("AuthorID")]
        public virtual Employee Author { get; set; }

        /// <summary>
        /// Внешний ключ сотрудника-автора
        /// </summary>
        public int ExecutorID { get; set; }

        /// <summary>
        /// Ссылка на сотрудника-исполнителя
        /// </summary>
        [ForeignKey("ExecutorID")]
        public virtual Employee Executor { get; set; }

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
