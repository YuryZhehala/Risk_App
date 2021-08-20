using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ViewModel.Models;

namespace ViewModel.Interfaces
{
   public interface IRiskSourceService
    {
        ObservableCollection<RiskSourceViewModel> GetAll();
        RiskSourceViewModel Get(int id);
        void AddIncidentToRiskSource(int RiskSourceId, IncidentViewModel incident);
        void RemoveIncidentFromRiskSource(int RiskSourceId, int incidentId);
        void CreateRiskSource(RiskSourceViewModel RiskSource);
        void DeleteRiskSource(int RiskSourceId);
        void UpdateRiskSource(RiskSourceViewModel RiskSource);
    }
}
