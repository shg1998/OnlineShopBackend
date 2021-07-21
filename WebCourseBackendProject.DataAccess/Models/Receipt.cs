using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebCourseBackendProject.DataAccess.Models
{
    public class Receipt
    {
        [Column("ReceiptId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ReceiptId { get; set; }
        
        [Column("ComCount")]
        [Required]
        public int ComCount { get; set; }


        [ForeignKey("ComId")]
        [Required]
        public virtual Commodity Commodity  { get; set; }

        [Column("UserId")]
        [Required]
        public virtual User user{ get; set; }

        [Column("FinalPrice")]
        [Required]
        public double FinalPrice { get; set; }


        [Column("ReceiptDate")]
        [Required]
        public long ReceiptDate { get; set; }

        [Column("ReceiptTrackingCode")]
        [Required]
        public double ReceiptTrackingCode { get; set; }

        [ForeignKey("StatusID")]
        [Required]
        public virtual Status ReceiptStatus { get; set; }
    }
}
