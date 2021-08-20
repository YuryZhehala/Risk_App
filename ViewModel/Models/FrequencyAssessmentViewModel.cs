using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class FrequencyAssessmentViewModel
    {
        public int FrequencyAssessmentId { get; set; }
        public string FrequencyAssessmentName { get; set; }
        public string FrequencyAssessmentRange { get; set; }
        public decimal FrequencyAssessmentValue { get; set; }
        public ObservableCollection<IncidentViewModel> Incidents
        { get; set; }
    }
}
