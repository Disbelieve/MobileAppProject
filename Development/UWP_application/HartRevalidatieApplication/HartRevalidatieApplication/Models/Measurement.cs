using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.Models
{
    public class Measurement
    {
        public int upperPressure { get; private set; } = 110;
        public int underPressure { get; private set; } = 90;
        public DateTime date { get; private set; } = DateTime.Now;
        public List<string> healthComplaints { get; private set; } = new List<string>();
        public string comment { get; private set; } = "";
        public string feedback { get; private set; } = "Uw bloeddruk was prima";

        public Measurement() { }
    }
}
