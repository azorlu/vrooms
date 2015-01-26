using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vrooms.Domain.Entities;

namespace Vrooms.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
    }
}
