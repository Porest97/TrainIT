using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainIT.Models;

namespace TrainIT.Data
{
    public class TrainITContext : IdentityDbContext<ApplicationUser>
    {
        public TrainITContext(DbContextOptions<TrainITContext> options)
            : base(options)
        {
        }

       
    }
}

