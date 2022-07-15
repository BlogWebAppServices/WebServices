using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kulturDelisiWebAPI.Models.categoryModel
{
    public class childCategory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

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

    }
}
