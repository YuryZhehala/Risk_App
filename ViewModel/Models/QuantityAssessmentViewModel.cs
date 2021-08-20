using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class QuantityAssessmentViewModel
    {
        public int QuantityAssessmentId { get; set; }
        public string QuantityAssessmentName { get; set; }
        public string QuantityAssessmentRange { get; set; }
        public decimal QuantityAssessmentValue { get; set; }
        public ObservableCollection<IncidentViewModel> Incidents
        { get; set; }
    }
}
