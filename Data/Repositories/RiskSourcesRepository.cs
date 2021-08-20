using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Entities;
using Data.EFContext;
using System.Data.Entity;

namespace Data.Repositories
{
    class RiskSourcesRepository : IRepository<RiskSource>
    {
        SourceRiskContext context;
        public RiskSourcesRepository(SourceRiskContext context)
        {
            this.context = context;
        }
        public void Create(RiskSource t)
        {
            context.RiskSources.Add(t);
        }
        public void Delete(int id)
        {
            var RiskSource = context.RiskSources.Find(id);
            context.RiskSources.Remove(RiskSource);
        }
        public IEnumerable<RiskSource> Find(Func<RiskSource, bool> predicate)
        {
            return context
            .RiskSources
            .Include(g => g.Incidents)
            .Where(predicate)
            .ToList();
        }
        public RiskSource Get(int id)
        {
            return context.RiskSources.Find(id);
        }
        public IEnumerable<RiskSource> GetAll()
        {
            return context.RiskSources.Include(g => g.Incidents);
        }
        public void Update(RiskSource t)
        {
            context.Entry<RiskSource>(t).State = EntityState.Modified;
        }
    }
}
