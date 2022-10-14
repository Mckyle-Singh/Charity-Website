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

//Build an Expense Tracker with Asp.Net Core MVC. 2022. YouTube video, added by CodeAffection. [Online]. Available at: 
//https://youtu.be/zQ5eijfpuu8 [Accessed 10 October 2022]