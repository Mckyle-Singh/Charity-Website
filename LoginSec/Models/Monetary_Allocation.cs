using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginSec.Models
{
    public class Monetary_Allocation
    {
        //primary key 
        [Key]
        public int MonetaryId { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Please select a Disaster")]
        public int DisasterId { get; set; }

        public Disaster? Disaster { get; set; }//Foerign key refernce 
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than zero")]

        public int Amount { get; set; }


        //Creating Title for category in transaction table
        [NotMapped]
        public string? DisasterTitle
        {
            get
            {
                return Disaster == null ? "" : Disaster.DisasterType;
            }
        }
    }
}
