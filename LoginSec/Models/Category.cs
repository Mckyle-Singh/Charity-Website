﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginSec.Models
{
    public class Category
    {
        [Key]//This is the primary key
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(50)")]//Specifying the dataTypes for the columns
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Type { get; set; } = "Monetary";//Default value

        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; }


        //Not mapped means it Doesnt effect the database
        [NotMapped]
        public string? TitleWithIcon
        {
            get
            {
                return this.Icon + " " + this.Title;
            }

        }
    }
}

//Build an Expense Tracker with Asp.Net Core MVC. 2022. YouTube video, added by CodeAffection. [Online]. Available at: 
//https://youtu.be/zQ5eijfpuu8 [Accessed 10 October 2022]