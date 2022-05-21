using kulturDelisiWebAPI.Models.permissionModel;

namespace kulturDelisiWebAPI.Models.UserModels
{
    public class UserDto : user
    {

        public int id { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public string fullName { get; set; }

        public string? phone { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public DateTime? birhtdate { get; set; }

        public DateTime createdate { get; set; }

        public DateTime? updatedate { get; set; }

        public Boolean isActive { get; set; }

        public Boolean isDeleted { get; set; }
        public permissions? permissions { get; set; }
    }
}
