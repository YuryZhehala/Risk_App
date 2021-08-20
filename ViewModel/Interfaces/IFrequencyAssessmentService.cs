using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.Interfaces
{
    public interface IFrequencyAssessmentService
    {
        ObservableCollection<FrequencyAssessmentViewModel> GetAll();
        FrequencyAssessmentViewModel Get(int id);
        void AddIncidentToFrequencyAssessment(int FrequencyAssessmentId, IncidentViewModel incident);
        void RemoveIncidentFromFrequencyAssessment(int FrequencyAssessmentId, int incidentId);
        void CreateFrequencyAssessment(FrequencyAssessmentViewModel FrequencyAssessment);
        void DeleteFrequencyAssessment(int FrequencyAssessmentId);
        void UpdateFrequencyAssessment(FrequencyAssessmentViewModel FrequencyAssessment);
    }
}
