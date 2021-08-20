using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{  
    public class QuantityAssessment
    {
        [Key]
        public int QuantityAssessmentId { get; set; }
        public string QuantityAssessmentName { get; set; }
        public string QuantityAssessmentRange { get; set; }
        public decimal QuantityAssessmentValue { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
