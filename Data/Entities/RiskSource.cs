using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class RiskSource
    {
        
        public int RiskSourceId { get; set; }
        public string RiskSourceName { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
