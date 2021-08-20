using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ViewModel.Models
{
    public class RiskSourceViewModel
    {
        
        public int RiskSourceId { get; set; }
        public string RiskSourceName { get; set; }
        public ObservableCollection<IncidentViewModel> Incidents
        { get; set; }
    }
}