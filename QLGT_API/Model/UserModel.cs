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
        [Key]
        public int Id { get; set; }
        public string Cmnd { get; set; }
        public string Password { get; set; }
        public int IsAdmin { get; set; } = 0;
        public int MA_KHACH_HANG { get; set; }
    }
}
