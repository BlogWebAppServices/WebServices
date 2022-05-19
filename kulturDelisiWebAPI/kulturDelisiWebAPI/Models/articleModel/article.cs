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
        public DateTime createTime { get; set; }

       
        public DateTime updateTime { get; set; }

        [Required]
        public String createUser { get; set; }


        public String? updateUser { get; set; }

        [Required]
        public Boolean isDeleted { get; set; }

        [Required]
        public  Boolean isActive { get; set; }
        
    }
}
