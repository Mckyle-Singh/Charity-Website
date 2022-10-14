using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginSec.Models
{
    public class GoodsDonation
    {
        [Key]
        public int GoodsId { get; set; } //primary key
                                         //
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }//Foerign key refernce 

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than zero")]
        public int NumItems { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Name { get; set; } = "Annonymous";  //Nullable(?) string because its not mandatory

        [Column(TypeName = "nvarchar(75)")]
        public string? ItemDescription { get; set; }   //Nullable(?) string because its not mandatory


        public DateTime Date { get; set; } = DateTime.Now;


        //Creating Title for category in transaction table
        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }
    }
}

//Build an Expense Tracker with Asp.Net Core MVC. 2022. YouTube video, added by CodeAffection. [Online]. Available at: 
//https://youtu.be/zQ5eijfpuu8 [Accessed 10 October 2022]