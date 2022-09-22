﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginSec.Models
{
    public class MonetaryDonation
    {
        [Key]
        public int MonetaryId { get; set; } //primary key 

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }//Foerign key refernce 

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than zero")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Name { get; set; } = "Annonymous";   //Nullable(?) string because its not mandatory


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