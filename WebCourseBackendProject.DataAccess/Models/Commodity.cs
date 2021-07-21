using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebCourseBackendProject.DataAccess.Models
{
    public class Commodity
    {
        [Column("ComId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ComId { get; set; }

        [Column("ComName")]
        [Required]
        [StringLength(50)]
        public string ComName { get; set; }

        // TODO : instance of category model

        
        public int CategoryId { get; set; }
        public  Category ComCategory { get; set; }


        [Column("ComPrice")]
        [Required]
        public double ComPrice { get; set; }

        [Column("ComRemained")]
        [Required]
        public int ComRemained { get; set; }


        [Column("ComSaledCount")]
        [Required]
        public int ComSaledCount { get; set; }

        [ForeignKey("ComId")]
        public ICollection<Receipt> Receipts { get; set; }
    }
}
