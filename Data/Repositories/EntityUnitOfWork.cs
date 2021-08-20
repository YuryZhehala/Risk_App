using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Data.EFContext;

namespace Data.Repositories
{
    public class EntityUnitOfWork : IUnitOfWork
    {
        SourceRiskContext context;
        RiskSourcesRepository RiskSourcesRepository;
        IncidentRepository IncidentsRepository;
        RiskObjectsRepository RiskObjectsRepository;
        LossTypesRepository LossTypesRepository;
        UnitsRepository UnitsRepository;
        QuantityAssessmentsRepository QuantityAssessmentsRepository;
        FrequencyAssessmentsRepository FrequencyAssessmentsRepository;
        DurationAssessmentsRepository DurationAssessmentsRepository;
        LossAssessmentsRepository LossAssessmentsRepository;

        public EntityUnitOfWork(string name)
        {
            context = new SourceRiskContext(name);
        }
        public IRepository<RiskSource> RiskSources
        {
            get
            {
                if (RiskSourcesRepository == null)
                    RiskSourcesRepository = new RiskSourcesRepository(context);
                return RiskSourcesRepository;
            }
        }
        public IRepository<Incident> Incidents
        {
            get
            {
                if (IncidentsRepository == null)
                    IncidentsRepository =
                    new IncidentRepository(context);
                return IncidentsRepository;
            }
        }
        public IRepository<RiskObject> RiskObjects
        {
            get
            {
                if (RiskObjectsRepository == null)
                    RiskObjectsRepository = new RiskObjectsRepository(context);
                return RiskObjectsRepository;
            }
        }
        public IRepository<LossType> LossTypes
        {
            get
            {
                if (LossTypesRepository == null)
                    LossTypesRepository = new LossTypesRepository(context);
                return LossTypesRepository;
            }
        }
        public IRepository<Unit> Units
        {
            get
            {
                if (UnitsRepository == null)
                    UnitsRepository = new UnitsRepository(context);
                return UnitsRepository;
            }
        }
        public IRepository<FrequencyAssessment> FrequencyAssessments
        {
            get
            {
                if (FrequencyAssessmentsRepository == null)
                    FrequencyAssessmentsRepository = new FrequencyAssessmentsRepository(context);
                return FrequencyAssessmentsRepository;
            }
        }
        public IRepository<QuantityAssessment> QuantityAssessments
        {
            get
            {
                if (QuantityAssessmentsRepository == null)
                    QuantityAssessmentsRepository = new QuantityAssessmentsRepository(context);
                return QuantityAssessmentsRepository;
            }
        }
        public IRepository<DurationAssessment> DurationAssessments
        {
            get
            {
                if (DurationAssessmentsRepository == null)
                    DurationAssessmentsRepository = new DurationAssessmentsRepository(context);
                return DurationAssessmentsRepository;
            }
        }
        public IRepository<LossAssessment> LossAssessments
        {
            get
            {
                if (LossAssessmentsRepository == null)
                    LossAssessmentsRepository = new LossAssessmentsRepository(context);
                return LossAssessmentsRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
