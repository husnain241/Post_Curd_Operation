using Post_Crud.Models;
using Microsoft.EntityFrameworkCore;


namespace Post_Crud.Models
{
    public class PostDBContext: DbContext
    {

        public PostDBContext(DbContextOptions<PostDBContext> options) : base(options)
        {

        }

        public DbSet<Post> posts { get; set; }

    }
}

