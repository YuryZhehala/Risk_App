using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data.Entities;

namespace Data.EFContext
{
    public class SourceRiskContext : DbContext
    {      
        public SourceRiskContext(string name) : base(name)
        {
            Database.SetInitializer(new SourceRiskInitializer());
        }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<RiskSource> RiskSources { get; set; }
        public DbSet<RiskObject> RiskObjects { get; set; }
        public DbSet<LossType> LossTypes { get; set; }
        public DbSet<FrequencyAssessment> FrequencyAssessment { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<LossAssessment> LossAssessments { get; set; }
        public DbSet<DurationAssessment> DurationAssessments { get; set; }
        public DbSet<QuantityAssessment> QuantityAssessments { get; set; }
    }
}
