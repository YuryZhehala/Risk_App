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
    
    class QuantityAssessmentsRepository : IRepository<QuantityAssessment>
    {
        SourceRiskContext context;
        public QuantityAssessmentsRepository(SourceRiskContext context)
        {
            this.context = context;
        }
        public void Create(QuantityAssessment t)
        {
            context.QuantityAssessments.Add(t);
        }
        public void Delete(int id)
        {
            var QuantityAssessment = context.QuantityAssessments.Find(id);
            context.QuantityAssessments.Remove(QuantityAssessment);
        }
        public IEnumerable<QuantityAssessment> Find(Func<QuantityAssessment, bool> predicate)
        {
            return context
            .QuantityAssessments
            .Include(g => g.Incidents)
            .Where(predicate)
            .ToList();
        }
        public QuantityAssessment Get(int id)
        {
            return context.QuantityAssessments.Find(id);
        }
        public IEnumerable<QuantityAssessment> GetAll()
        {
            return context.QuantityAssessments.Include(g => g.Incidents);
        }
        public void Update(QuantityAssessment t)
        {
            context.Entry<QuantityAssessment>(t).State = EntityState.Modified;
        }
    }
}
