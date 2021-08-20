using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class LossTypeViewModel
    {
        public int LossTypeId { get; set; }
        public string LossTypeName { get; set; }
        public ObservableCollection<IncidentViewModel> Incidents
        { get; set; }
    }
}
