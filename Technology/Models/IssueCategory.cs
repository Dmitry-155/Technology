namespace Technology.WebPortal.Models
{
    /// <summary>
    /// Категория обращения
    /// </summary>
    public class IssueCategory
    {
        /// <summary>
        /// Идентификатор категории обращения
        /// </summary>
        public int IssueCategoryID { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Описание типа
        /// </summary>
        public string Description { get; set; }
    }
}
