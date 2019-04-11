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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Meeting Date")]
        public DateTime MeetingDate { get; set; }

        public string Conductor { get; set; }
        public string Presiding { get; set; }
        public string Invocation { get; set; }
        public string Benediction { get; set; }

        //songs
        [Required]
        [Display(Name = "Opening Hymn")]
        public int OpeningHymn { get; set; }

        [Required]
        [Display(Name = "Sacrament Hymn")]
        public int SacramentHymn { get; set; }

        [Display(Name = "Intermediate Hymn")]
        public int IntermediateHymn { get; set; }

        [Required]
        [Display(Name = "Closing Hymn")]
        public int ClosingHymn { get; set; }

        public ICollection<Speaker> Speakers { get; set; }

    }
}