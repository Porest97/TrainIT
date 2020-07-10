using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainIT.Models.DataModels
{
    public class Workout
    {
        public int Id { get; set; }


        [Display(Name = "Started date&time")]
        public DateTime DateTimeStarted { get; set; }

        [Display(Name = "Ended date&time")]
        public DateTime DateTimeEnded { get; set; }

        [Display(Name = "Location")]
        public int? ArenaId { get; set; }
        [Display(Name = "Location")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        [Display(Name = "Sport")]
        public int? SportId { get; set; }
        [Display(Name = "Sport")]
        [ForeignKey("SportId")]
        public Sport Sport { get; set; }

        [Display(Name = "Owner")]
        public int? PersonId { get; set; }
        [Display(Name = "Owner")]
        [ForeignKey("PersonId")]
        public Person Owner { get; set; }

        [Display(Name = "Duration (hh,mm)")]
        public decimal Duration { get; set; }

        [Display(Name = "Distance (km)")]
        public decimal Distance { get; set; }

        [Display(Name = "Kcal")]
        public decimal Kcal { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; } = false;
    }
}
