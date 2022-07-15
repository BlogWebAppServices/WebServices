using kulturDelisiWebAPI.Models.articleModel;
using kulturDelisiWebAPI.Models.categoryModel;
using kulturDelisiWebAPI.Models.contactModel;
using kulturDelisiWebAPI.Models.permissionModel;
using kulturDelisiWebAPI.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace kulturDelisiWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<article> Articles { get; set; }
        public DbSet<category> Categories { get; set; }
        public DbSet<childCategory> childCategories { get; set; }
        public DbSet<contact> Contacts { get; set; }
        public DbSet<permissions> Permissions { get; set; }
        public DbSet<user> Users { get; set; }


    }
}
