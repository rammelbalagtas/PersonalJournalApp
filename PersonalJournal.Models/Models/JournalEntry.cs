using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalJournal.Models.Models
{
    public class JournalEntry
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [ForeignKey("Category")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Mood")]
        [DisplayName("Mood")]
        public int MoodId { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }

        [ForeignKey("Subsection1")]
        [DisplayName("Subsection 1")]
        public int SubsectionId1 { get; set; }
        [DisplayName("Subsection Description")]
        public string SubsectionText1 { get; set; }

        [ForeignKey("Subsection2")]
        [DisplayName("Subsection 2")]
        public int SubsectionId2 { get; set; }
        [DisplayName("Subsection Description")]
        public string SubsectionText2 { get; set; }

        [ForeignKey("Subsection3")]
        [DisplayName("Subsection 3")]
        public int SubsectionId3 { get; set; }
        [DisplayName("Subsection Description")]
        public string SubsectionText3 { get; set; }

        [ForeignKey("Subsection4")]
        [DisplayName("Subsection 4")]
        public int SubsectionId4 { get; set; }
        [DisplayName("Subsection Description")]
        public string SubsectionText4 { get; set; }

        [ForeignKey("Subsection5")]
        [DisplayName("Subsection 5")]
        public int SubsectionId5 { get; set; }
        [DisplayName("Subsection Description")]
        public string SubsectionText5 { get; set; }

        public Category Category { get; set; }
        public Mood Mood { get; set; }
        public Subsection Subsection1 { get; set; }
        public Subsection Subsection2 { get; set; }
        public Subsection Subsection3 { get; set; }
        public Subsection Subsection4 { get; set; }
        public Subsection Subsection5 { get; set; }

    }
}
