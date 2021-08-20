using Data.EFContext;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    
        class RiskObjectsRepository : IRepository<RiskObject>
        {
            SourceRiskContext context;
            public RiskObjectsRepository(SourceRiskContext context)
            {
                this.context = context;
            }
            public void Create(RiskObject t)
            {
                context.RiskObjects.Add(t);
            }
            public void Delete(int id)
            {
                var RiskObject = context.RiskObjects.Find(id);
                context.RiskObjects.Remove(RiskObject);
            }
            public IEnumerable<RiskObject> Find(Func<RiskObject, bool> predicate)
            {
                return context
                .RiskObjects
                .Include(g => g.Incidents)
                .Where(predicate)
                .ToList();
            }
            public RiskObject Get(int id)
            {
                return context.RiskObjects.Find(id);
            }
            public IEnumerable<RiskObject> GetAll()
            {
                return context.RiskObjects.Include(g => g.Incidents);
            }
            public void Update(RiskObject t)
            {
                context.Entry<RiskObject>(t).State = EntityState.Modified;
            }
        }
}
