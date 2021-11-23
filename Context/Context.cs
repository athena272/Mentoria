using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Check2.Context
{
    public class Context : DbContext
    {
        public System.Data.Entity.DbSet<Check2.Models.Donos> Donos { get; set; }
        public System.Data.Entity.DbSet<Check2.Models.Caes> Caes { get; set; }
        public System.Data.Entity.DbSet<Check2.Models.Caes_Dono> Caes_Dono { get; set; }
        public System.Data.Entity.DbSet<Check2.Models.Racas> Racas { get; set; }
    }
}