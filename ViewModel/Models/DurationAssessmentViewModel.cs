using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class DurationAssessmentViewModel
    {
        public int DurationAssessmentId { get; set; }
        public string DurationAssessmentName { get; set; }
        public string DurationAssessmentRange { get; set; }
        public decimal DurationAssessmentValue { get; set; }
        public ObservableCollection<IncidentViewModel> Incidents
        { get; set; }
    }
}