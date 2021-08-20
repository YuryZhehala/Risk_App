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
    public class DurationAssessmentService : IDurationAssessmentService
    {
        IUnitOfWork dataBase;
        public DurationAssessmentService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void AddIncidentToDurationAssessment(int DurationAssessmentId, IncidentViewModel incidentVM)
        {
            var DurationAssessment = dataBase.DurationAssessments.Get(DurationAssessmentId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncidentViewModel, Incident>());
            var mapper = config.CreateMapper();
            var incident = mapper.Map<Incident>(incidentVM);
            DurationAssessment.Incidents.Add(incident);
            dataBase.Save();
        }
        public void CreateDurationAssessment(DurationAssessmentViewModel DurationAssessment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DurationAssessmentViewModel, DurationAssessment>());
            var mapper = config.CreateMapper();
            DurationAssessment DurationAssessment_new = mapper.Map<DurationAssessment>(DurationAssessment);
            dataBase.DurationAssessments.Create(DurationAssessment_new);
            dataBase.Save();
        }
        public void DeleteDurationAssessment(int DurationAssessmentId)
        {
            dataBase.DurationAssessments.Delete(DurationAssessmentId);
            dataBase.Save();
        }
        public DurationAssessmentViewModel Get(int id)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<DurationAssessmentViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DurationAssessment, DurationAssessmentViewModel>();
                cfg.CreateMap<Incident, IncidentViewModel>();
            });
            var mapper = config.CreateMapper();
            var DurationAssessments = mapper.Map<ObservableCollection<DurationAssessmentViewModel>>(dataBase.DurationAssessments.GetAll());
            return DurationAssessments;
        }
        public void RemoveIncidentFromDurationAssessment(int DurationAssessmentId, int incidentId)
        {
            DurationAssessment DurationAssessment = dataBase.DurationAssessments.Get(DurationAssessmentId);
            DurationAssessment.Incidents.Remove(dataBase.Incidents.Get(incidentId));
            dataBase.DurationAssessments.Update(DurationAssessment);
            dataBase.Incidents.Delete(incidentId);
            dataBase.Save();
        }
        public void UpdateDurationAssessment(DurationAssessmentViewModel DurationAssessmentVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DurationAssessmentViewModel, DurationAssessment>());
            var mapper = config.CreateMapper();
            DurationAssessment DurationAssessment_new = mapper.Map<DurationAssessment>(DurationAssessmentVM);
            dataBase.DurationAssessments.Update(mapper.Map<DurationAssessment>(DurationAssessment_new));
            dataBase.Save();
        }
    }
}
