using System.ComponentModel.DataAnnotations;

namespace kulturDelisiWebAPI.Models.categoryModel
{
    public class category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string categoryName { get; set; }


        [Required]
        public DateTime createDate { get; set; }
        
        public DateTime? updateDate { get; set; }


        [Required]
        public int createUserId { get; set; }
   
        public int? updateUserId { get; set; }


        [Required]
        public Boolean isDeleted { get; set; }


        [Required]
        public Boolean isActive { get; set; }

        public bool IsSelected
        {
            get { return false; }
        }

    }
}
