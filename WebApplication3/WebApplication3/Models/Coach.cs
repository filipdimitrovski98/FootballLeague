using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Coach
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Презиме")]
        public string LastName { get; set; }
       
        [Display(Name = "Претходно освоени титули")]
        [Range(0, 50)]
        public int NumberOfTitles { get; set; }
        [StringLength(20)]
        [Display(Name = "Држава")]
        public string Country { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Роденден")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Име и презиме")]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }
        [NotMapped]
        [Display(Name = "Возраст")]
        public int Age
        {
            get
            {
                TimeSpan span = DateTime.Now - BirthDate;
                double years = (double)span.TotalDays / 365.2425;
                return (int)years;
            }
        }
        [Display(Name = "Клуб")]
        
        public int? TeamId { get; set; }
        [Display(Name = "Клуб")]
        [ForeignKey("TeamId")]

        public Team Team { get; set; }
    }
}
