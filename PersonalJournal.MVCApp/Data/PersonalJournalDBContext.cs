using Microsoft.EntityFrameworkCore;
using PersonalJournal.Models.Models;

namespace PersonalJournal.MVCApp.Data
{
    public class PersonalJournalDBContext : DbContext
    {
        public PersonalJournalDBContext(DbContextOptions<PersonalJournalDBContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subsection> Subsections { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Add navigation
            //modelBuilder.Entity<Category>().Navigation(d => d.JournalEntries).AutoInclude(true);
            //modelBuilder.Entity<Mood>().Navigation(d => d.JournalEntries).AutoInclude(true);
            //modelBuilder.Entity<JournalEntry>().Navigation(d => d.Category).AutoInclude(true);
            //modelBuilder.Entity<JournalEntry>().Navigation(d => d.Mood).AutoInclude(true);
            //modelBuilder.Entity<JournalEntry>().Navigation(d => d.Subsection1).AutoInclude(true);
            //modelBuilder.Entity<JournalEntry>().Navigation(d => d.Subsection2).AutoInclude(true);
            //modelBuilder.Entity<JournalEntry>().Navigation(d => d.Subsection3).AutoInclude(true);
            //modelBuilder.Entity<JournalEntry>().Navigation(d => d.Subsection4).AutoInclude(true);
            //modelBuilder.Entity<JournalEntry>().Navigation(d => d.Subsection5).AutoInclude(true);
        }
    }
}
