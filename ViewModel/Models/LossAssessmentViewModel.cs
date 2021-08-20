using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class LossAssessmentViewModel
    {
        public int LossAssessmentId { get; set; }
        public string LossAssessmentName { get; set; }
        public string LossAssessmentRange { get; set; }
        public decimal LossAssessmentValue { get; set; }
        public ObservableCollection<IncidentViewModel> Incidents
        { get; set; }
    }
}
