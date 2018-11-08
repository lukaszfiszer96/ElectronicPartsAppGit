using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ElectronicParts.Domain.Entities;

namespace ElectronicParts.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<ElectronicPart> ElectronicParts { get; set; }
    }
}