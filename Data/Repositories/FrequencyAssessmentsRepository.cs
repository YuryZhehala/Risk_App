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
    
    class FrequencyAssessmentsRepository : IRepository<FrequencyAssessment>
    {
        SourceRiskContext context;
        public FrequencyAssessmentsRepository(SourceRiskContext context)
        {
            this.context = context;
        }
        public void Create(FrequencyAssessment t)
        {
            context.FrequencyAssessment.Add(t);
        }
        public void Delete(int id)
        {
            var FrequencyAssessment = context.FrequencyAssessment.Find(id);
            context.FrequencyAssessment.Remove(FrequencyAssessment);
        }
        public IEnumerable<FrequencyAssessment> Find(Func<FrequencyAssessment, bool> predicate)
        {
            return context
            .FrequencyAssessment
            .Include(g => g.Incidents)
            .Where(predicate)
            .ToList();
        }
        public FrequencyAssessment Get(int id)
        {
            return context.FrequencyAssessment.Find(id);
        }
        public IEnumerable<FrequencyAssessment> GetAll()
        {
            return context.FrequencyAssessment.Include(g => g.Incidents);
        }
        public void Update(FrequencyAssessment t)
        {
            context.Entry<FrequencyAssessment>(t).State = EntityState.Modified;
        }
    }
}
