using Microsoft.EntityFrameworkCore;
using SettingMDMLookupsDataRelations.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class MDMLookupsDbContext:DbContext
    {
        public MDMLookupsDbContext(DbContextOptions<MDMLookupsDbContext> options) : base(options)
        {}
        public DbSet<Major> Majors { get; set; }
        public DbSet<MinistryMajor> MinistryMajors { get; set; }
    }
}
