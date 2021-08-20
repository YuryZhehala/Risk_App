using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<RiskSource> RiskSources { get; }
        IRepository<Incident> Incidents { get; }
        IRepository<RiskObject> RiskObjects { get; }
        IRepository<LossType> LossTypes { get; }
        IRepository<Unit> Units { get; }
        IRepository<FrequencyAssessment> FrequencyAssessments { get; }
        IRepository<LossAssessment> LossAssessments { get; }
        IRepository<DurationAssessment> DurationAssessments { get; }
        IRepository<QuantityAssessment> QuantityAssessments { get; }
        void Save();
    }
}
