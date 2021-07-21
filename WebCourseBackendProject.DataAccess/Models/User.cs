using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebCourseBackendProject.DataAccess.Models
{
    public class User
    {
        [Column("UserId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }

        [Column("UserName")]
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }


        [Column("FullName")]
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Column("Password")]
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Column("UserAddress")]
        [Required]
        [StringLength(250)]
        public string UserAddress { get; set; }


        [Column("AccountCharge")]
        [Required]
        public int AccountCharge { get; set; }


        [ForeignKey("RoleId")]
        [Required]
        public virtual Role Role { get; set; }
    }
}
