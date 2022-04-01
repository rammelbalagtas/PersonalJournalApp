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
        [ForeignKey("Subsection")]
        [DisplayName("Subsection 1")]
        public int SubSection1 { get; set; }
        [DisplayName("Subsection Description")]
        public string SubSectionText1 { get; set; }
        [ForeignKey("Subsection")]
        [DisplayName("Subsection 2")]
        public int SubSection2 { get; set; }
        [DisplayName("Subsection Description")]
        public string SubSectionText2 { get; set; }
        [ForeignKey("Subsection")]
        [DisplayName("Subsection 3")]
        public int SubSection3 { get; set; }
        [DisplayName("Subsection Description")]
        public string SubSectionText3 { get; set; }
        [ForeignKey("Subsection")]
        [DisplayName("Subsection 4")]
        public int SubSection4 { get; set; }
        [DisplayName("Subsection Description")]
        public string SubSectionText4 { get; set; }
        [ForeignKey("Subsection")]
        [DisplayName("Subsection 5")]
        public int SubSection5 { get; set; }
        [DisplayName("Subsection Description")]
        public string SubSectionText5 { get; set; }
        public Category Category { get; set; }
        public Subsection Subsection { get; set; }

    }
}
