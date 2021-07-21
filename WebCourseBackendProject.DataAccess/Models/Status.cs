using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebCourseBackendProject.DataAccess.Models
{
    public class Status
    {

        [Column("StatusID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int StatusID { get; set; }


        [Column("StatusName")]
        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }
    }
}
