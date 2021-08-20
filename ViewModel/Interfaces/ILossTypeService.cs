using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.Interfaces
{
    public interface ILossTypeService
    {
        ObservableCollection<LossTypeViewModel> GetAll();
        LossTypeViewModel Get(int id);
        void AddIncidentToLossType(int LossTypeId, IncidentViewModel incident);
        void RemoveIncidentFromLossType(int LossTypeId, int incidentId);
        void CreateLossType(LossTypeViewModel LossType);
        void DeleteLossType(int LossTypeId);
        void UpdateLossType(LossTypeViewModel LossType);
    }
}
