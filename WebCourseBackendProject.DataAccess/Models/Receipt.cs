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


        public int ComId { get; set; }
        public Commodity Commodity { get; set; }

        public int UserID { get; set; }
        public User user { get; set; }

        [Column("FinalPrice")]
        [Required]
        public double FinalPrice { get; set; }


        [Column("ReceiptDate")]
        [Required]
        public long ReceiptDate { get; set; }

        [Column("ReceiptTrackingCode")]
        [Required]
        public double ReceiptTrackingCode { get; set; }


        public int StatusID { get; set; }
        public Status ReceiptStatus { get; set; }
    }
}
