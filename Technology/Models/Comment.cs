using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technology.WebPortal.Models
{
    /// <summary>
    /// Категория обращения
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Идентификатор категории обращения
        /// </summary>
        public int CommentID { get; set; }

        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата и время комментария
        /// </summary>
        public DateTime Date { get; set; }

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
        /// Внешний ключ обращения
        /// </summary>
        public int IssueID { get; set; }

        /// <summary>
        /// Ссылка на обращение
        /// </summary>
        [ForeignKey("IssueID")]
        public virtual Issue Issue { get; set; }

        /// <summary>
        /// Ссылка на тип обращения
        /// </summary>
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
