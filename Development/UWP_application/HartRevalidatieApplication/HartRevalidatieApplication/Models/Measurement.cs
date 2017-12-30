using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.Models
{
    public class Measurement
    {
        public int bloodPressureUpper { get; set; }
        public int bloodPressureLower { get; set; }
        public DateTime measurementDateTime { get; set; }
        public List<string> healthIssueIds { get; set; }
        public List<string> healthIssues { get; set; }
        public string healthIssueOther { get; set; }
    }
}
