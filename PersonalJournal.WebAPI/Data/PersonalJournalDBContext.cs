using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalJournal.Models.Models;

namespace PersonalJournal.WebAPI.Data
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
    }
}
