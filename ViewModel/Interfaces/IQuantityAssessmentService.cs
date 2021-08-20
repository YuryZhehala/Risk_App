using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.Interfaces
{
    public interface IQuantityAssessmentService
    {
        ObservableCollection<QuantityAssessmentViewModel> GetAll();
        QuantityAssessmentViewModel Get(int id);
        void AddIncidentToQuantityAssessment(int QuantityAssessmentId, IncidentViewModel incident);
        void RemoveIncidentFromQuantityAssessment(int QuantityAssessmentId, int incidentId);
        void CreateQuantityAssessment(QuantityAssessmentViewModel QuantityAssessment);
        void DeleteQuantityAssessment(int QuantityAssessmentId);
        void UpdateQuantityAssessment(QuantityAssessmentViewModel QuantityAssessment);
    }
}
