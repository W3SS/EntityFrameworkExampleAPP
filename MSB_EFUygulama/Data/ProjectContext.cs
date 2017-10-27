using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB_EFUygulama.Data
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Data Source=.;Initial Catalog=MSBEFUygulama;uid=sa;pwd=1234;MultipleActiveResultSets=True";
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Role> Role { get; set; }

    }
}
