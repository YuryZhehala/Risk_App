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
    
    class DurationAssessmentsRepository : IRepository<DurationAssessment>
    {
        SourceRiskContext context;
        public DurationAssessmentsRepository(SourceRiskContext context)
        {
            this.context = context;
        }
        public void Create(DurationAssessment t)
        {
            context.DurationAssessments.Add(t);
        }
        public void Delete(int id)
        {
            var DurationAssessment = context.DurationAssessments.Find(id);
            context.DurationAssessments.Remove(DurationAssessment);
        }
        public IEnumerable<DurationAssessment> Find(Func<DurationAssessment, bool> predicate)
        {
            return context
            .DurationAssessments
            .Include(g => g.Incidents)
            .Where(predicate)
            .ToList();
        }
        public DurationAssessment Get(int id)
        {
            return context.DurationAssessments.Find(id);
        }
        public IEnumerable<DurationAssessment> GetAll()
        {
            return context.DurationAssessments.Include(g => g.Incidents);
        }
        public void Update(DurationAssessment t)
        {
            context.Entry<DurationAssessment>(t).State = EntityState.Modified;
        }
    }
}
