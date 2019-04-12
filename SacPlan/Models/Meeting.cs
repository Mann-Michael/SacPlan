using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SacPlan.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Meeting Date")]
        public DateTime MeetingDate { get; set; }

        [Required]
        public string Conductor { get; set; }

        [Required]
        public string Presiding { get; set; }

        [Required]
        public string Invocation { get; set; }

        [Required]
        public string Benediction { get; set; }

        //songs
        [Required, Range(1, 341)]
        [Display(Name = "Opening Hymn")]
        public int OpeningHymn { get; set; }

        [Required, Range(1, 341)]
        [Display(Name = "Sacrament Hymn")]
        public int SacramentHymn { get; set; }

        [Display(Name = "Intermediate Hymn")]
        public int IntermediateHymn { get; set; }

        [Required, Range(1, 341)]
        [Display(Name = "Closing Hymn")]
        public int ClosingHymn { get; set; }

        public ICollection<Speaker> Speakers { get; set; }

    }
}