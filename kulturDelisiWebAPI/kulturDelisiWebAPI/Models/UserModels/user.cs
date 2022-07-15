using kulturDelisiWebAPI.Models.permissionModel;
using System.ComponentModel.DataAnnotations;

namespace kulturDelisiWebAPI.Models.UserModels
{
    public class user
    {

        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        [Required]
        [StringLength(30)]
        public string surname { get; set; }

        [Required]
        [StringLength(100)]
        public string fullName { get; set; }

        public string? phone { get; set; }

        public string? city { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        public DateTime? birhtdate { get; set; }
         
        public string? profilePhoto { get; set; }

        public string? userAbout { get; set; }

        [Required]
        public DateTime createdate { get; set; }

        public DateTime? updatedate { get; set; }

        [Required]
        public Boolean isActive { get; set; }

        [Required]
        public Boolean isDeleted { get; set; }

        [Required]
        public int permissionLevelId { get; set; }

  
        public bool IsSelected
        {
            get { return false; }
        }

    }



}
