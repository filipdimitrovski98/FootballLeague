using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Contract
    {
        public int Id { get; set; }
        [Display(Name = "Играч")]
        
        public int PlayerId { get; set; }
        [Display(Name = "Играч")]
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }
        [Display(Name = "Клуб")]
        public int TeamId { get; set; }
        [Display(Name = "Клуб")]
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        [Display(Name = "Годишна плата")]
        [DataType(DataType.Currency)]
        public int Salary { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Датум на потпишување на договорот")]
        public DateTime StartingDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Датум на истекување на договорот")]
        public DateTime FinishDate { get; set; }
        [NotMapped]
        public bool Valid
        {
            get
            {
                int result = DateTime.Compare(FinishDate, DateTime.Now);
                if (result > 0)
                    return false;
                else return true;

            }
        }


    }
}
