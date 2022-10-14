using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginSec.Models
{
    public class PurchaseGoods
    {
        //primary key 
        [Key]
        public int PurchaseId { get; set; }


        [Column(TypeName = "nvarchar(75)")]
        public string? ItemDescription { get; set; }   //Nullable(?) string because its not mandatory

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than zero")]
        public int PurchaseAmount { get; set; }


        [Column(TypeName = "nvarchar(10)")]
        public string Type { get; set; } = "Expense";//Default value 


        [Range(1, int.MaxValue, ErrorMessage = "Please select a Disaster")]
        public int DisasterId { get; set; }
        public Disaster? Disaster { get; set; }//Foerign key refernce 

        public DateTime Date { get; set; } = DateTime.Now;


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