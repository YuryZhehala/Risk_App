using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.Interfaces
{
    public interface IRiskObjectService
    {
        ObservableCollection<RiskObjectViewModel> GetAll();
        RiskObjectViewModel Get(int id);
        void AddIncidentToRiskObject(int RiskObjectId, IncidentViewModel incident);
        void RemoveIncidentFromRiskObject(int RiskObjectId, int incidentId);
        void CreateRiskObject(RiskObjectViewModel RiskObject);
        void DeleteRiskObject(int RiskObjectId);
        void UpdateRiskObject(RiskObjectViewModel RiskObject);
    }
}
