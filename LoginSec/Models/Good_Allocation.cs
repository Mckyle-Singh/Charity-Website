using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginSec.Models
{
    public class Good_Allocation
    {
        //primary key 
        [Key]
        public int GoodsAllocationId { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Please select the type of goods")]
        public int GoodsId { get; set; }
        public GoodsDonation? GoodsDonation { get; set; }//Foerign key refernce 


        [Range(1, int.MaxValue, ErrorMessage = "Please select a Disaster")]
        public int DisasterId { get; set; }
        public Disaster? Disaster { get; set; }//Foerign key refernce 

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than zero")]
        public int NumItems { get; set; }


        public DateTime Date { get; set; } = DateTime.Now;

        //Creating Title for Disasters in Goods_Allocation table
        [NotMapped]
        public string? DisasterTitle
        {
            get
            {
                return Disaster == null ? "" : Disaster.DisasterType;
            }
        }


        //Creating Title for GoodsDonations in Goods_Allocation table
        [NotMapped]
        public string? AllocationTitle
        {
            get
            {
                return GoodsDonation == null ? "" : GoodsDonation.ItemDescription;
            }
        }
    }
}
