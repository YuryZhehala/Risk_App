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
    public class IncidentService : IIncidentService
    {

        IUnitOfWork dataBase;
        public IncidentService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void ChangeIncidentRiskSource(int SourceRiskId, int incidentId)
        {
            throw new NotImplementedException();
        }

        public void CreateIncident (IncidentViewModel incidentVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncidentViewModel, Incident>());
            var mapper = config.CreateMapper();
            dataBase.Incidents.Create(mapper.Map<Incident>(incidentVM));
            dataBase.Save();
        }

        public void DeleteIncident(int incidentId)
        {
            dataBase.Incidents.Delete(incidentId);
            dataBase.Save();
        }

        public IncidentViewModel Get(int incidentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateIncident(IncidentViewModel incidentVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncidentViewModel, Incident>());
            var mapper = config.CreateMapper();
            dataBase.Incidents.Update(mapper.Map<Incident>(incidentVM));
            dataBase.Save();
        }
        public ObservableCollection<IncidentViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Incident, IncidentViewModel>();
            });
            var mapper = config.CreateMapper();
            var RiskSources = mapper.Map<ObservableCollection<IncidentViewModel>>(dataBase.Incidents.GetAll());
            return RiskSources;
        }
    } 
}
