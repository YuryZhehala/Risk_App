using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;


namespace ViewModel.Interfaces
{
    public interface ILossAssessmentservice
    {
        ObservableCollection<LossAssessmentViewModel> GetAll();
        LossAssessmentViewModel Get(int id);
        void AddIncidentToLossAssessment(int LossAssessmentId, IncidentViewModel incident);
        void RemoveIncidentFromLossAssessment(int LossAssessmentId, int incidentId);
        void CreateLossAssessment(LossAssessmentViewModel LossAssessment);
        void DeleteLossAssessment(int LossAssessmentId);
        void UpdateLossAssessment(LossAssessmentViewModel LossAssessment);
    }
}
