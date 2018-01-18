using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.Models
{
    public class RecoverPasswordTemplate
    {
        public string password { get; set; }
        public string confirmedPassword { get; set; }
        public string token { get; set; }

    }
}
