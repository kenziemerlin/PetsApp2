using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetsApp2.Models;

namespace PetsApp2.Data
{
    public class PetsApp2Context : DbContext
    {
        public PetsApp2Context (DbContextOptions<PetsApp2Context> options)
            : base(options)
        {
        }

        public DbSet<PetsApp2.Models.Cat> Cat { get; set; } = default!;
    }
}
