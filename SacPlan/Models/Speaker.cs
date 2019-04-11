using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacPlan.Models
{
    public class Speaker
    {
        //Primary Key
        public int SpeakerID { get; set; }

        //Name Stuff
        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        //Misc Information
        [Required]
        [StringLength(100, ErrorMessage = "Topic cannot be longer than 100 characters.")]
        public string Topic { get; set; }

        [Required]
        public int Order { get; set; }

        public int? MeetingID { get; set; }
    }
}