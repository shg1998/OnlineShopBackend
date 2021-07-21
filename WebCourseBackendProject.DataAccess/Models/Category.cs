using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebCourseBackendProject.DataAccess.Models
{
    public class Category
    {
        [Column("CatId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CatId { get; set; }

        [Column("CotName")]
        [Required]
        [StringLength(50)]
        public string CotName { get; set; }
    }
}
