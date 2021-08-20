using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class RiskObjectViewModel
    {
        public int RiskObjectId { get; set; }
        public string RiskObjectName { get; set; }
        public ObservableCollection<IncidentViewModel> Incidents
        { get; set; }
    }
}
