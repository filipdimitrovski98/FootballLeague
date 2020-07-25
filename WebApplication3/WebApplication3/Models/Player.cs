using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Player
    {   
        public int Id { get; set; }

        
        [Required]
        [Display(Name = "Број на дрес")]
        public int JerseyNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Презиме")]
        public string LastName { get; set; }
        [Display(Name = "Тежина - kg ")]
        [Range(50, 150)]
        public int Weight { get; set; }
        [Display(Name = "Висина - cm")]
        [Range(150, 220)]
        public int Height { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Позиција")]
        public string Position { get; set; }
        
        [StringLength(20)]
        [Display(Name = "Преферирана нога")]
        public string PrefferedLeg { get; set; }
        [Display(Name = "Постигнати голови во кариера")]
        [Range(0, 1500)]
        public int Goals { get; set; }
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
        public int? ContractId { get; set; }
        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }
        public int? ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }



    }
}
