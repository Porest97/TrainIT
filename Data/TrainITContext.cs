using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainIT.Models;
using TrainIT.Models.DataModels;

namespace TrainIT.Data
{
    public class TrainITContext : IdentityDbContext<ApplicationUser>
    {
        public TrainITContext(DbContextOptions<TrainITContext> options)
            : base(options)
        {
        }
        public DbSet<TrainIT.Models.DataModels.Arena> Arena { get; set; }
        public DbSet<TrainIT.Models.DataModels.DustTest> DustTest { get; set; }
        public DbSet<TrainIT.Models.DataModels.Person> Person { get; set; }
        public DbSet<TrainIT.Models.DataModels.Sport> Sport { get; set; }
        public DbSet<TrainIT.Models.DataModels.Workout> Workout { get; set; }

       
    }
}

