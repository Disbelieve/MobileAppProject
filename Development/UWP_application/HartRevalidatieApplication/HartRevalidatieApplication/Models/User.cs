using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.Models
{
    public class User
    {
        public static User SingleInstance { get; set; } = new User();

        public string emailAddress { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string consultantId { get; set; }
        public string dateOfBirth { get; set; } //in database as string
        public int gender { get; set; }
        public double weight { get; set; }
        public double length { get; set; }

        //public string password { get; set; } 

        public string authToken { get; set; }

        public DateTime GetBirthDateToDateTime()
        {
            return Convert.ToDateTime(dateOfBirth);
        }

        public static void SetUser(User u)
        {
            SingleInstance = u;
        }
    }
}
