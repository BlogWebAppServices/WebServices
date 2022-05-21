namespace kulturDelisiWebAPI.Models.categoryModel
{
    public class categoryPagedDto
    {
        public int Id { get; set; }

        public string categoryName { get; set; }


        public DateTime createDate { get; set; }
    
        public int createUserId { get; set; }
   
        public Boolean isDeleted { get; set; }

        public Boolean isActive { get; set; }

        public bool IsSelected
        {
            get { return false;}
        }

    }
}