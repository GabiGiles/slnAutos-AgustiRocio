using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using WSAuto.Models;

namespace WSAuto.Data
{
    public class DbSWAutoContext:DbContext
    {
        public DbSWAutoContext(DbContextOptions<DbSWAutoContext> options) : base(options) { }
        public DbSet<Auto> Autos { get; set; }
    }
}
