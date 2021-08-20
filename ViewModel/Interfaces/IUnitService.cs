using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.Interfaces
{
    public interface IUnitService
    {
        ObservableCollection<UnitViewModel> GetAll();
        UnitViewModel Get(int id);
        void AddIncidentToUnit(int UnitId, IncidentViewModel incident);
        void RemoveIncidentFromUnit(int UnitId, int incidentId);
        void CreateUnit(UnitViewModel Unit);
        void DeleteUnit(int UnitId);
        void UpdateUnit(UnitViewModel Unit);
    }
}
