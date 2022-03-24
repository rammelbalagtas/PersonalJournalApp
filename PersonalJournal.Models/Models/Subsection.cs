using System.ComponentModel.DataAnnotations;


namespace PersonalJournal.Models.Models
{
    public class Subsection
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string LongDescription { get; set; }
    }
}
