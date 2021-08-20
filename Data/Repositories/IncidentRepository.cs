using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Entities;
using Data.EFContext;
using System.Data.Entity;

namespace Data.Repositories
{
    class IncidentRepository : IRepository<Incident>
    {
        SourceRiskContext context;
        public IncidentRepository(SourceRiskContext context)
        {
            this.context = context;
        }
        public void Create(Incident t)
        {
            context.Incidents.Add(t);
        }
        public void Delete(int id)
        {
            var incident = context.Incidents.Find(id);
            context.Incidents.Remove(incident);
        }
        public IEnumerable<Incident> Find(Func<Incident, bool> predicate)
        {
            return context
            .Incidents
            .Include(g => g.RiskSource)
            .Where(predicate)
            .ToList();
        }
        public Incident Get(int id)
        {
            return context.Incidents.Find(id);
        }
        public IEnumerable<Incident> GetAll()
        {
            return context.Incidents.Include(g => g.RiskSource);
        }
        public void Update(Incident t)
        {
            context.Entry<Incident>(t).State = EntityState.Modified;
        }
    }
}
