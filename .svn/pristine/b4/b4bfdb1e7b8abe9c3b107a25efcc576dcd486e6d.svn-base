using System.Data.Entity;
using Comments.Data.Implementation;
using Comments.Facebook.Model;

namespace Comments.Data.Context
{
    public class SmoEntities : SmoEntitiesBase
    {
        public SmoEntities()
        {
            Configuration.LazyLoadingEnabled = false; // turn off easy loading
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Users> User { get; set; }
        public DbSet<FacebookAccessToken> FacebookAccessToken { get; set; }
    }
}