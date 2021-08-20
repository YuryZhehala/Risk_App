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
    public class LossAssessmentservice : ILossAssessmentservice
    {
        IUnitOfWork dataBase;
        public LossAssessmentservice(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void AddIncidentToLossAssessment(int LossAssessmentId, IncidentViewModel incidentVM)
        {
            var LossAssessment = dataBase.LossAssessments.Get(LossAssessmentId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncidentViewModel, Incident>());
            var mapper = config.CreateMapper();
            var incident = mapper.Map<Incident>(incidentVM);
            LossAssessment.Incidents.Add(incident);
            dataBase.Save();
        }
        public void CreateLossAssessment(LossAssessmentViewModel LossAssessment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LossAssessmentViewModel, LossAssessment>());
            var mapper = config.CreateMapper();
            LossAssessment LossAssessment_new = mapper.Map<LossAssessment>(LossAssessment);
            dataBase.LossAssessments.Create(LossAssessment_new);
            dataBase.Save();
        }
        public void DeleteLossAssessment(int LossAssessmentId)
        {
            dataBase.LossAssessments.Delete(LossAssessmentId);
            dataBase.Save();
        }
        public LossAssessmentViewModel Get(int id)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<LossAssessmentViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LossAssessment, LossAssessmentViewModel>();
                cfg.CreateMap<Incident, IncidentViewModel>();
            });
            var mapper = config.CreateMapper();
            var LossAssessments = mapper.Map<ObservableCollection<LossAssessmentViewModel>>(dataBase.LossAssessments.GetAll());
            return LossAssessments;
        }
        public void RemoveIncidentFromLossAssessment(int LossAssessmentId, int incidentId)
        {
            LossAssessment LossAssessment = dataBase.LossAssessments.Get(LossAssessmentId);
            LossAssessment.Incidents.Remove(dataBase.Incidents.Get(incidentId));
            dataBase.LossAssessments.Update(LossAssessment);
            dataBase.Incidents.Delete(incidentId);
            dataBase.Save();
        }
        public void UpdateLossAssessment(LossAssessmentViewModel LossAssessmentVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LossAssessmentViewModel, LossAssessment>());
            var mapper = config.CreateMapper();
            LossAssessment LossAssessment_new = mapper.Map<LossAssessment>(LossAssessmentVM);
            dataBase.LossAssessments.Update(mapper.Map<LossAssessment>(LossAssessment_new));
            dataBase.Save();
        }
    }
}
