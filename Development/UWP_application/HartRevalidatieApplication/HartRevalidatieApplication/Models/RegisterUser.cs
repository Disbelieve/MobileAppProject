using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.Models
{
    public class RegisterUser
    {
        public string emailAddress { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string consultantId { get; set; }
        public string dateOfBirth { get; set; }
        public int gender { get; set; }
        public string password { get; set; } 
    }
}
