using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainIT.Data
{
    public class TrainITContext : IdentityDbContext
    {
        public TrainITContext(DbContextOptions<TrainITContext> options)
            : base(options)
        {
        }

       
    }
}

