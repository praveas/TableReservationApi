using System;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data.DB
{
    public class CommanderContext : DbContext // inherited from Db Base class
    {
        public CommanderContext(DbContextOptions<CommanderContext> options): base(options)
        {
           
        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<AllAvailableTimes> AllAvailableTimes { get; set; }
    }
}
