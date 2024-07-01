using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECAN_INVOICE.Models
{

    public class Users
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string FullName { get; set; } = "";
        [Required(ErrorMessage = "Required Field")]
        public string username { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string pasword { get; set; }
      
      
    } 
    public class Product
    {
        [Key]
        [MaxLength(50)]
        public string strId { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string S_No { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public DateTime DateOfPurchase { get; set; } = DateTime.UtcNow.AddHours(3);
        [Required(ErrorMessage = "Required Field")]
        public string Supplier_Name { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public DateTime DaliveryDate { get; set; } = DateTime.UtcNow.AddHours(3);
        [Required(ErrorMessage = "Required Field")]
        public string ReceivedBy { get; set; }


    }

}
