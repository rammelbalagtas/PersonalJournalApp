using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalJournal.Models.Models
{
    public class Mood
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public ICollection<JournalEntry> JournalEntries { get; set; }
    }
}
