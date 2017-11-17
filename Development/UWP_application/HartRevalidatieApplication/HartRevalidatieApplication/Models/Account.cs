using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.Models
{
    public static class Account
    {
        public static string firstName { get; private set; }
        public static string lastName { get; private set; }
        public static string email { get; private set; }
        public static string gender { get; private set; }
        public static string age { get; private set; }
        public static string weight { get; private set; }
        public static string height { get; private set; }
        public static string consultant { get; private set; }
        public static DateTime birthDate { get; private set; }
    }
}
