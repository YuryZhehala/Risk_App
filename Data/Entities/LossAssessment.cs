using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class LossAssessment
    {
        public int LossAssessmentId { get; set; }
        public string LossAssessmentName { get; set; }
        public string LossAssessmentRange { get; set; }
        public decimal LossAssessmentValue { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
