using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ViewModel.Models;

namespace ViewModel.Interfaces
{
    public interface IIncidentService
    {
        ObservableCollection<IncidentViewModel> GetAll();
        IncidentViewModel Get(int incidentId);
        void ChangeIncidentRiskSource(int RiskSourceId, int incidentId);
        void CreateIncident(IncidentViewModel incident);
        void DeleteIncident(int incidentId);
        void UpdateIncident(IncidentViewModel incident);
    }
}