using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class UnitViewModel
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public ObservableCollection<IncidentViewModel> Incidents
        { get; set; }
    }
}
