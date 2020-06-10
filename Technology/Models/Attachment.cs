using System.ComponentModel.DataAnnotations.Schema;

namespace Technology.WebPortal.Models
{
    /// <summary>
    /// Категория обращения
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Идентификатор категории обращения
        /// </summary>
        public int AttachmentID { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Контект файла
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Внешний ключ комментария
        /// </summary>
        public int CommentID { get; set; }

        /// <summary>
        /// Ссылка на комментарий
        /// </summary>
        [ForeignKey("CommentID")]
        public virtual Comment Comment { get; set; }
    }
}
