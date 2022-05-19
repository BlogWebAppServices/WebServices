using System.ComponentModel.DataAnnotations;

namespace kulturDelisiWebAPI.Models.permissionModel
{
    public class permissions
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int level { get; set; }

        [Required]
        public string name { get; set; }

    }
}
