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
    public class RiskSourceService : IRiskSourceService
    {
        IUnitOfWork dataBase;
        public RiskSourceService (string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void AddIncidentToRiskSource(int RiskSourceId, IncidentViewModel incidentVM)
        {
            var RiskSource = dataBase.RiskSources.Get(RiskSourceId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncidentViewModel, Incident>());
            var mapper = config.CreateMapper();
            var incident = mapper.Map<Incident>(incidentVM);
            RiskSource.Incidents.Add(incident);
            dataBase.Save();
        }
        public void CreateRiskSource(RiskSourceViewModel RiskSource)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RiskSourceViewModel, RiskSource>());
            var mapper = config.CreateMapper();
            RiskSource RiskSource_new = mapper.Map<RiskSource>(RiskSource);
            dataBase.RiskSources.Create(RiskSource_new);
            dataBase.Save();
        }
        public void DeleteRiskSource(int RiskSourceId)
        {
            dataBase.RiskSources.Delete(RiskSourceId);
            dataBase.Save();
        }
        public RiskSourceViewModel Get(int id)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<RiskSourceViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RiskSource, RiskSourceViewModel>();
                cfg.CreateMap<Incident, IncidentViewModel>();
            });
            var mapper = config.CreateMapper();
            var RiskSources = mapper.Map<ObservableCollection<RiskSourceViewModel>>(dataBase.RiskSources.GetAll());
            return RiskSources;
        }
        public void RemoveIncidentFromRiskSource(int RiskSourceId, int incidentId)
        {
            RiskSource RiskSource = dataBase.RiskSources.Get(RiskSourceId);
            RiskSource.Incidents.Remove(dataBase.Incidents.Get(incidentId));
            dataBase.RiskSources.Update(RiskSource);
            dataBase.Incidents.Delete(incidentId);
            dataBase.Save();
        }
        public void UpdateRiskSource(RiskSourceViewModel RiskSourceVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RiskSourceViewModel, RiskSource>());
            var mapper = config.CreateMapper();
            RiskSource RiskSource_new = mapper.Map<RiskSource>(RiskSourceVM);
            dataBase.RiskSources.Update(mapper.Map<RiskSource>(RiskSource_new));
            dataBase.Save();
        }
    }
}
