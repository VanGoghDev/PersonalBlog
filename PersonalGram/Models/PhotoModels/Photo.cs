using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PersonalGram.Models.PhotoModels
{
    /// <summary>
    /// Класс, который представляет собой базовое фото
    /// с именем и данными в виде byte[] для хранения в базе
    /// </summary>
    public class Photo
    {
        public int Id { get; set; }
        
        [Required]
        public HttpPostedFileBase File { get; set; }
        
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// Данные
        /// </summary>
        public byte[] Content { get; set; }
    }
}