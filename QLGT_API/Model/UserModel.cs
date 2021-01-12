using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Model
{
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        [Key]
        public int ID_ACCOUNT { get; set; }
        public string CMND { get; set; }
        public string PASS_WORD { get; set; }
        public int IS_ADMIN { get; set; } 
        public int MA_KHACH_HANG { get; set; }
    }
}
