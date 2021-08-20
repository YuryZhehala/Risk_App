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
    
    class LossAssessmentsRepository : IRepository<LossAssessment>
    {
        SourceRiskContext context;
        public LossAssessmentsRepository(SourceRiskContext context)
        {
            this.context = context;
        }
        public void Create(LossAssessment t)
        {
            context.LossAssessments.Add(t);
        }
        public void Delete(int id)
        {
            var LossAssessment = context.LossAssessments.Find(id);
            context.LossAssessments.Remove(LossAssessment);
        }
        public IEnumerable<LossAssessment> Find(Func<LossAssessment, bool> predicate)
        {
            return context
            .LossAssessments
            .Include(g => g.Incidents)
            .Where(predicate)
            .ToList();
        }
        public LossAssessment Get(int id)
        {
            return context.LossAssessments.Find(id);
        }
        public IEnumerable<LossAssessment> GetAll()
        {
            return context.LossAssessments.Include(g => g.Incidents);
        }
        public void Update(LossAssessment t)
        {
            context.Entry<LossAssessment>(t).State = EntityState.Modified;
        }
    }
}
