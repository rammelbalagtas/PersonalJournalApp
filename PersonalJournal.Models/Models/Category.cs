using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonalJournal.Models.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [DisplayName("Description")]
        public string LongDescription { get; set; }
        public string CreatedByUser { get; set; }
        public ICollection<JournalEntry> JournalEntries { get; set; }
    }
}
