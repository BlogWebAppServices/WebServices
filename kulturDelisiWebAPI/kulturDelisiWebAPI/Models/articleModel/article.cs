using System.ComponentModel.DataAnnotations;

namespace kulturDelisiWebAPI.Models.articleModel
{
    public class article
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string content { get; set; }

        [Required]
        public string metaDescription { get; set; }

        [Required]
        public string metaTitle { get; set; }

        [Required]
        public DateTime createTime { get; set; }

       
        public DateTime? updateTime { get; set; }

        [Required]
        public int createUser { get; set; }

        [Required]
        public int categoryId { get; set; }

        public int? updateUser { get; set; }

        [Required]
        public Boolean isDeleted { get; set; }

        [Required]
        public  Boolean isActive { get; set; }
        
    }
}
