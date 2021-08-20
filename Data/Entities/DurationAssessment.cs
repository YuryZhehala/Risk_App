using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class DurationAssessment
    {
        public int DurationAssessmentId { get; set; }
        public string DurationAssessmentName { get; set; }
        public string DurationAssessmentRange { get; set; }
        public decimal DurationAssessmentValue { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
