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
    class LossTypesRepository : IRepository<LossType>
    {
        SourceRiskContext context;
        public LossTypesRepository(SourceRiskContext context)
        {
            this.context = context;
        }
        public void Create(LossType t)
        {
            context.LossTypes.Add(t);
        }
        public void Delete(int id)
        {
            var LossType = context.LossTypes.Find(id);
            context.LossTypes.Remove(LossType);
        }
        public IEnumerable<LossType> Find(Func<LossType, bool> predicate)
        {
            return context
            .LossTypes
            .Include(g => g.Incidents)
            .Where(predicate)
            .ToList();
        }
        public LossType Get(int id)
        {
            return context.LossTypes.Find(id);
        }
        public IEnumerable<LossType> GetAll()
        {
            return context.LossTypes.Include(g => g.Incidents);
        }
        public void Update(LossType t)
        {
            context.Entry<LossType>(t).State = EntityState.Modified;
        }
    }
}
