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
    public class RiskObjectService : IRiskObjectService
    {
        IUnitOfWork dataBase;
        public RiskObjectService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void AddIncidentToRiskObject(int RiskObjectId, IncidentViewModel incidentVM)
        {
            var RiskObject = dataBase.RiskObjects.Get(RiskObjectId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncidentViewModel, Incident>());
            var mapper = config.CreateMapper();
            var incident = mapper.Map<Incident>(incidentVM);
            RiskObject.Incidents.Add(incident);
            dataBase.Save();
        }
        public void CreateRiskObject(RiskObjectViewModel RiskObject)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RiskObjectViewModel, RiskObject>());
            var mapper = config.CreateMapper();
            RiskObject RiskObject_new = mapper.Map<RiskObject>(RiskObject);
            dataBase.RiskObjects.Create(RiskObject_new);
            dataBase.Save();
        }
        public void DeleteRiskObject(int RiskObjectId)
        {
            dataBase.RiskObjects.Delete(RiskObjectId);
            dataBase.Save();
        }
        public RiskObjectViewModel Get(int id)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<RiskObjectViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RiskObject, RiskObjectViewModel>();
                cfg.CreateMap<Incident, IncidentViewModel>();
            });
            var mapper = config.CreateMapper();
            var RiskObjects = mapper.Map<ObservableCollection<RiskObjectViewModel>>(dataBase.RiskObjects.GetAll());
            return RiskObjects;
        }
        public void RemoveIncidentFromRiskObject(int RiskObjectId, int incidentId)
        {
            RiskObject RiskObject = dataBase.RiskObjects.Get(RiskObjectId);
            RiskObject.Incidents.Remove(dataBase.Incidents.Get(incidentId));
            dataBase.RiskObjects.Update(RiskObject);
            dataBase.Incidents.Delete(incidentId);
            dataBase.Save();
        }
        public void UpdateRiskObject(RiskObjectViewModel RiskObjectVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RiskObjectViewModel, RiskObject>());
            var mapper = config.CreateMapper();
            RiskObject RiskObject_new = mapper.Map<RiskObject>(RiskObjectVM);
            dataBase.RiskObjects.Update(mapper.Map<RiskObject>(RiskObject_new));
            dataBase.Save();
        }
    }
}
