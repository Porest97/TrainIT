using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainIT.Models.DataModels
{
    public class DustTest
    {
        public int Id { get; set; }


        [Display(Name = "Test date&time")]
        public DateTime DateTimePreformed { get; set; }

        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        [Display(Name = "Sport")]
        public int? SportId { get; set; }
        [Display(Name = "Sport")]
        [ForeignKey("SportId")]
        public Sport Sport { get; set; }

        [Display(Name = "Tested person")]
        public int? PersonId { get; set; }
        [Display(Name = "Tested Person")]
        [ForeignKey("PersonId")]
        public Person TestedPerson { get; set; }

        [Display(Name = "#1")]
        public decimal TimeSet1 { get; set; }

        [Display(Name = "#2")]
        public decimal TimeSet2 { get; set; }

        [Display(Name = "#3")]
        public decimal TimeSet3 { get; set; }

        [Display(Name = "#4")]
        public decimal TimeSet4 { get; set; }

        [Display(Name = "Total time (Seconds)")]
        public decimal TimeTotal { get; set; }

        [Display(Name = "Approved")]
        public bool Approved { get; set; }
    }
}
