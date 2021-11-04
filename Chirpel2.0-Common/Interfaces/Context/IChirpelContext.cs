using Chirpel2._0_Common.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirpel2._0_Common.Interfaces.Context
{
    public interface IChirpelContext: IDbContext, IDisposable
    {
        DbSet<PostModel> Post { get; set; }
        DbSet<UserModel> User { get; set; }
    }
}
