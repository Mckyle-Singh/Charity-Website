using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginSec.Models
{
    public class Disaster
    {
        [Key]//This is the primary key
        public int DisasterId { get; set; }

        [Column(TypeName = "nvarchar(20)")]//Specifying the dataTypes for the columns
        public string DisasterType { get; set; }

        [Column(TypeName = "nvarchar(50)")]//Specifying the dataTypes for the columns
        public string DisasterLocation { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Description { get; set; }   //Nullable(?) string because its not mandatory

        [Column(TypeName = "nvarchar(75)")]
        public string? RequiredAids { get; set; }   //Nullable(?) string because its not mandatory

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}

//Build an Expense Tracker with Asp.Net Core MVC. 2022. YouTube video, added by CodeAffection. [Online]. Available at: 
//https://youtu.be/zQ5eijfpuu8 [Accessed 10 October 2022]