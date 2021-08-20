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
    public class LossTypeService : ILossTypeService
    {
        IUnitOfWork dataBase;
        public LossTypeService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void AddIncidentToLossType(int LossTypeId, IncidentViewModel incidentVM)
        {
            var LossType = dataBase.LossTypes.Get(LossTypeId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncidentViewModel, Incident>());
            var mapper = config.CreateMapper();
            var incident = mapper.Map<Incident>(incidentVM);
            LossType.Incidents.Add(incident);
            dataBase.Save();
        }
        public void CreateLossType(LossTypeViewModel LossType)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LossTypeViewModel, LossType>());
            var mapper = config.CreateMapper();
            LossType LossType_new = mapper.Map<LossType>(LossType);
            dataBase.LossTypes.Create(LossType_new);
            dataBase.Save();
        }
        public void DeleteLossType(int LossTypeId)
        {
            dataBase.LossTypes.Delete(LossTypeId);
            dataBase.Save();
        }
        public LossTypeViewModel Get(int id)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<LossTypeViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LossType, LossTypeViewModel>();
                cfg.CreateMap<Incident, IncidentViewModel>();
            });
            var mapper = config.CreateMapper();
            var LossTypes = mapper.Map<ObservableCollection<LossTypeViewModel>>(dataBase.LossTypes.GetAll());
            return LossTypes;
        }
        public void RemoveIncidentFromLossType(int LossTypeId, int incidentId)
        {
            LossType LossType = dataBase.LossTypes.Get(LossTypeId);
            LossType.Incidents.Remove(dataBase.Incidents.Get(incidentId));
            dataBase.LossTypes.Update(LossType);
            dataBase.Incidents.Delete(incidentId);
            dataBase.Save();
        }
        public void UpdateLossType(LossTypeViewModel LossTypeVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LossTypeViewModel, LossType>());
            var mapper = config.CreateMapper();
            LossType LossType_new = mapper.Map<LossType>(LossTypeVM);
            dataBase.LossTypes.Update(mapper.Map<LossType>(LossType_new));
            dataBase.Save();
        }
    }
}
