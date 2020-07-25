using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Стадион")]
        public string StadiumName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Град")]
        public string City { get; set; }
        [Display(Name = "Број на освоени титули во лига")]
        public int NumberTitles { get; set; }
        [Display(Name="Играчи")]
        public ICollection <Contract> Players { get; set; }
        public int? CoachId { get; set; }
        [ForeignKey("CoachId")]

        public Coach Coach { get; set; }







    }
}
