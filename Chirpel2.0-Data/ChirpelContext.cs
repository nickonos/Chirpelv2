using Chirpel2._0_Common.Interfaces.Context;
using Chirpel2._0_Common.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Chirpel2._0_Data
{
    public class ChirpelContext : DbContext, IChirpelContext
    {
        public DbSet<PostModel> Post { get; set; }
        public DbSet<UserModel> User {  get; set; }

        public ChirpelContext(DbContextOptions<ChirpelContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder model)
        {

        }
    }
}