using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Form2
{
    internal class DbScolaire : DbContext

    {
        public DbScolaire() { }
        public DbScolaire() : base("connectioniage") { }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Etudiant> Etudiant { get; set; }
    }
}
