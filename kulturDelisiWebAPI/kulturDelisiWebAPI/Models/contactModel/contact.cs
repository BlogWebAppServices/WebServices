using System.ComponentModel.DataAnnotations;

namespace kulturDelisiWebAPI.Models.contactModel
{
    public class contact
    {
        [Key]
        public int Id { get; set; }

        public string? phone { get; set; }

        public string? email { get; set; }

        public string? adress { get; set; }

        public string? instagramLink { get; set; }

        public string? facebookLink { get; set; }

        public string? linedinLink { get; set; }

        public string? twitterLlink { get; set; }

        public DateTime? createDate {  get; set; }

        public DateTime? updateDate { get; set; }

        [Required]
        public int createUser { get; set; }

        public int? updateUser { get; set; }

    }
}
