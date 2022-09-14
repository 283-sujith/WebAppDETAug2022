using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ODataDemo.Models;

namespace ODataDemo.Data
{
    public class ODataDemoContext : DbContext
    {
        public ODataDemoContext (DbContextOptions<ODataDemoContext> options)
            : base(options)
        {
        }

        public DbSet<ODataDemo.Models.Student> Student { get; set; } = default!;
    }
}
