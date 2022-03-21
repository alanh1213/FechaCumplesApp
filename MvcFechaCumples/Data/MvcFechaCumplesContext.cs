using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcFechaCumples.Models;

namespace MvcFechaCumples.Data
{
    public class MvcFechaCumplesContext : DbContext
    {
        public MvcFechaCumplesContext (DbContextOptions<MvcFechaCumplesContext> options)
            : base(options)
        {
        }

        public DbSet<MvcFechaCumples.Models.Cumple> Cumple { get; set; }
    }
}
