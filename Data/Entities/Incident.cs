using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Incident
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
        public RiskSource RiskSource { get; set; }

        public RiskSource RiskSourceld
        {
            get => default;
            set
            {
            }
        }
        public int RiskObjectId { get; set; }
        public RiskObject RiskObject { get; set; }
        public string RiskObjectName { get; set; }
        public RiskObject RiskObjectld
        {
            get => default;
            set
            {
            }
        }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public Unit Unitld
        {
            get => default;
            set
            {
            }
        }
        public int LossTypeId { get; set; }
        public LossType LossType { get; set; }

        public LossType LossTypeld
        {
            get => default;
            set
            {
            }
        }

        public int FrequencyAssessmentId { get; set; }
        public FrequencyAssessment FrequencyAssessment { get; set; }

        public FrequencyAssessment FrequencyAssessmentld
        {
            get => default;
            set
            {
            }
        }
        public int QuantityAssessmentId { get; set; }
        public QuantityAssessment QuantityAssessment { get; set; }

        public QuantityAssessment QuantityAssessmentld
        {
            get => default;
            set
            {
            }
        }
        public int LossAssessmentId { get; set; }
        public LossAssessment LossAssessment { get; set; }

        public LossAssessment LossAssessmentld
        {
            get => default;
            set
            {
            }
        }
        public int DurationAssessmentId { get; set; }
        public DurationAssessment DurationAssessment { get; set; }

        public DurationAssessment DurationAssessmentld
        {
            get => default;
            set
            {
            }
        }
    }
}

