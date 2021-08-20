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
    public class FrequencyAssessmentService : IFrequencyAssessmentService
    {
        IUnitOfWork dataBase;
        public FrequencyAssessmentService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void AddIncidentToFrequencyAssessment(int FrequencyAssessmentId, IncidentViewModel incidentVM)
        {
            var FrequencyAssessment = dataBase.FrequencyAssessments.Get(FrequencyAssessmentId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncidentViewModel, Incident>());
            var mapper = config.CreateMapper();
            var incident = mapper.Map<Incident>(incidentVM);
            FrequencyAssessment.Incidents.Add(incident);
            dataBase.Save();
        }
        public void CreateFrequencyAssessment(FrequencyAssessmentViewModel FrequencyAssessment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FrequencyAssessmentViewModel, FrequencyAssessment>());
            var mapper = config.CreateMapper();
            FrequencyAssessment FrequencyAssessment_new = mapper.Map<FrequencyAssessment>(FrequencyAssessment);
            dataBase.FrequencyAssessments.Create(FrequencyAssessment_new);
            dataBase.Save();
        }
        public void DeleteFrequencyAssessment(int FrequencyAssessmentId)
        {
            dataBase.FrequencyAssessments.Delete(FrequencyAssessmentId);
            dataBase.Save();
        }
        public FrequencyAssessmentViewModel Get(int id)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<FrequencyAssessmentViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FrequencyAssessment, FrequencyAssessmentViewModel>();
                cfg.CreateMap<Incident, IncidentViewModel>();
            });
            var mapper = config.CreateMapper();
            var FrequencyAssessments = mapper.Map<ObservableCollection<FrequencyAssessmentViewModel>>(dataBase.FrequencyAssessments.GetAll());
            return FrequencyAssessments;
        }
        public void RemoveIncidentFromFrequencyAssessment(int FrequencyAssessmentId, int incidentId)
        {
            FrequencyAssessment FrequencyAssessment = dataBase.FrequencyAssessments.Get(FrequencyAssessmentId);
            FrequencyAssessment.Incidents.Remove(dataBase.Incidents.Get(incidentId));
            dataBase.FrequencyAssessments.Update(FrequencyAssessment);
            dataBase.Incidents.Delete(incidentId);
            dataBase.Save();
        }
        public void UpdateFrequencyAssessment(FrequencyAssessmentViewModel FrequencyAssessmentVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FrequencyAssessmentViewModel, FrequencyAssessment>());
            var mapper = config.CreateMapper();
            FrequencyAssessment FrequencyAssessment_new = mapper.Map<FrequencyAssessment>(FrequencyAssessmentVM);
            dataBase.FrequencyAssessments.Update(mapper.Map<FrequencyAssessment>(FrequencyAssessment_new));
            dataBase.Save();
        }
    }
}
