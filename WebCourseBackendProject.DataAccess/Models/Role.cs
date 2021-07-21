using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebCourseBackendProject.DataAccess.Models
{
    public class Role
    {
        [Column("RoleId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RoleId { get; set; }

        [Column("RoleName")]
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [ForeignKey("RoleID")]
        public ICollection<User> Users { get; set; }

    }
}
