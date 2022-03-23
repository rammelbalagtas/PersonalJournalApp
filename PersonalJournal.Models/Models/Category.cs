﻿using System.ComponentModel.DataAnnotations;

namespace PersonalJournal.Models.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public string LongDescription { get; set; }
    }
}
