using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FrequencyAssessment
    {
        public int FrequencyAssessmentId { get; set; }
        public string FrequencyAssessmentName { get; set; }
        public string FrequencyAssessmentRange { get; set; }
        public decimal FrequencyAssessmentValue { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
