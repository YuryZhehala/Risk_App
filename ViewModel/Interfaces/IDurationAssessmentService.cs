using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.Interfaces
{
    public interface IDurationAssessmentService
    {
        ObservableCollection<DurationAssessmentViewModel> GetAll();
        DurationAssessmentViewModel Get(int id);
        void AddIncidentToDurationAssessment(int DurationAssessmentId, IncidentViewModel incident);
        void RemoveIncidentFromDurationAssessment(int DurationAssessmentId, int incidentId);
        void CreateDurationAssessment(DurationAssessmentViewModel DurationAssessment);
        void DeleteDurationAssessment(int DurationAssessmentId);
        void UpdateDurationAssessment(DurationAssessmentViewModel DurationAssessment);
    }
}
