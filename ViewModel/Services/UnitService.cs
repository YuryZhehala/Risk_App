using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;
using ViewModel.Models;

namespace ViewModel.Services
{
    public class UnitService : IUnitService
    {
        IUnitOfWork dataBase;
        public UnitService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void AddIncidentToUnit(int UnitId, IncidentViewModel incidentVM)
        {
            var Unit = dataBase.Units.Get(UnitId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncidentViewModel, Incident>());
            var mapper = config.CreateMapper();
            var incident = mapper.Map<Incident>(incidentVM);
            Unit.Incidents.Add(incident);
            dataBase.Save();
        }
        public void CreateUnit(UnitViewModel Unit)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UnitViewModel, Unit>());
            var mapper = config.CreateMapper();
            Unit Unit_new = mapper.Map<Unit>(Unit);
            dataBase.Units.Create(Unit_new);
            dataBase.Save();
        }
        public void DeleteUnit(int UnitId)
        {
            dataBase.Units.Delete(UnitId);
            dataBase.Save();
        }
        public UnitViewModel Get(int id)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<UnitViewModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Unit, UnitViewModel>();
                cfg.CreateMap<Incident, IncidentViewModel>();
            });
            var mapper = config.CreateMapper();
            var Units = mapper.Map<ObservableCollection<UnitViewModel>>(dataBase.Units.GetAll());
            return Units;
        }
        public void RemoveIncidentFromUnit(int UnitId, int incidentId)
        {
            Unit Unit = dataBase.Units.Get(UnitId);
            Unit.Incidents.Remove(dataBase.Incidents.Get(incidentId));
            dataBase.Units.Update(Unit);
            dataBase.Incidents.Delete(incidentId);
            dataBase.Save();
        }
        public void UpdateUnit(UnitViewModel UnitVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UnitViewModel, Unit>());
            var mapper = config.CreateMapper();
            Unit Unit_new = mapper.Map<Unit>(UnitVM);
            dataBase.Units.Update(mapper.Map<Unit>(Unit_new));
            dataBase.Save();
        }
    }
}
