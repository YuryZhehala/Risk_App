using System;
using System.Collections.ObjectModel;
using ViewModel.Interfaces;
using Data.Entities;
using ViewModel.Models;
using Data.Interfaces;
using Data.Repositories;
using AutoMapper;

namespace ViewModel.Services
{
    public class QuantityAssessmentService : IQuantityAssessmentService
    {
        IUnitOfWork dataBase;
        public QuantityAssessmentService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void AddIncidentToQuantityAssessment(int QuantityAssessmentId, IncidentViewModel incidentVM)
        {
            var QuantityAssessment = dataBase.QuantityAssessments.Get(QuantityAssessmentId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncidentViewModel, Incident>());
            var mapper = config.CreateMapper();
            var incident = mapper.Map<Incident>(incidentVM);
            QuantityAssessment.Incidents.Add(incident);
            dataBase.Save();
        }
        public void CreateQuantityAssessment(QuantityAssessmentViewModel QuantityAssessment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuantityAssessmentViewModel, QuantityAssessment>());
            var mapper = config.CreateMapper();
            QuantityAssessment QuantityAssessment_new = mapper.Map<QuantityAssessment>(QuantityAssessment);
            dataBase.QuantityAssessments.Create(QuantityAssessment_new);
            dataBase.Save();
        }
        public void DeleteQuantityAssessment(int QuantityAssessmentId)
        {
            dataBase.QuantityAssessments.Delete(QuantityAssessmentId);
            dataBase.Save();
        }
        public QuantityAssessmentViewModel Get(int id)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<QuantityAssessmentViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<QuantityAssessment, QuantityAssessmentViewModel>();
                cfg.CreateMap<Incident, IncidentViewModel>();
            });
            var mapper = config.CreateMapper();
            var QuantityAssessments = mapper.Map<ObservableCollection<QuantityAssessmentViewModel>>(dataBase.QuantityAssessments.GetAll());
            return QuantityAssessments;
        }
        public void RemoveIncidentFromQuantityAssessment(int QuantityAssessmentId, int incidentId)
        {
            QuantityAssessment QuantityAssessment = dataBase.QuantityAssessments.Get(QuantityAssessmentId);
            QuantityAssessment.Incidents.Remove(dataBase.Incidents.Get(incidentId));
            dataBase.QuantityAssessments.Update(QuantityAssessment);
            dataBase.Incidents.Delete(incidentId);
            dataBase.Save();
        }
        public void UpdateQuantityAssessment(QuantityAssessmentViewModel QuantityAssessmentVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuantityAssessmentViewModel, QuantityAssessment>());
            var mapper = config.CreateMapper();
            QuantityAssessment QuantityAssessment_new = mapper.Map<QuantityAssessment>(QuantityAssessmentVM);
            dataBase.QuantityAssessments.Update(mapper.Map<QuantityAssessment>(QuantityAssessment_new));
            dataBase.Save();
        }
    }
}
