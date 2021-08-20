using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ViewModel.Models
{
    public class IncidentViewModel
    {
        public int IncidentId { get; set; }
        public DateTime DateOfIncident { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal DirectLossType { get; set; }
        public decimal PotentialLossType { get; set; }
        public int Assessment { get; set; }
        public string Measures { get; set; }
        public int RiskSourceId { get; set; }
        public int RiskObjectId { get; set; }
        public string RiskObjectName { get; set; }
        public int LossTypeId { get; set; }
        public int UnitId { get; set; }
        public int FrequencyAssessmentId { get; set; }
        public int QuantityAssessmentId { get; set; }
        public int LossAssessmentId { get; set; }
        public int DurationAssessmentId { get; set; }
    }
}