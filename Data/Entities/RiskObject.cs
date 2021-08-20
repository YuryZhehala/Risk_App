using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class RiskObject
    {     
        public int RiskObjectId { get; set; }
        public string RiskObjectName { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
