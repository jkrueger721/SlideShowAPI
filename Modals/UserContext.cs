using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;


namespace SlideShowAPI.Modals
{
    public class UserContext : DbContext
    {
        public DbSet<User> Blogs { get; set; }
        //public DbSet<Post> Posts { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    }
}
