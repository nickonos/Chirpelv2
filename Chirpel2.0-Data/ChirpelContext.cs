using Chirpel2._0_Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chirpel2._0_Data
{
    public class ChirpelContext : DbContext, IChirpelContext
    {
        public ChirpelContext(DbContextOptions<ChirpelContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder model)
        {

        }
    }
}