using Donatello2020.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello2020.Infrastructure
{
    public class Donatello2020Context : DbContext
    {
        public Donatello2020Context(DbContextOptions<Donatello2020Context> options) : base(options)
        {

        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Column> Columns { get; set; }
    }
}
