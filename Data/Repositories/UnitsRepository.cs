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
    class UnitsRepository : IRepository<Unit>
    {
        SourceRiskContext context;
        public UnitsRepository(SourceRiskContext context)
        {
            this.context = context;
        }
        public void Create(Unit t)
        {
            context.Units.Add(t);
        }
        public void Delete(int id)
        {
            var Unit = context.Units.Find(id);
            context.Units.Remove(Unit);
        }
        public IEnumerable<Unit> Find(Func<Unit, bool> predicate)
        {
            return context
            .Units
            .Include(g => g.Incidents)
            .Where(predicate)
            .ToList();
        }
        public Unit Get(int id)
        {
            return context.Units.Find(id);
        }
        public IEnumerable<Unit> GetAll()
        {
            return context.Units.Include(g => g.Incidents);
        }
        public void Update(Unit t)
        {
            context.Entry<Unit>(t).State = EntityState.Modified;
        }
    }
}
