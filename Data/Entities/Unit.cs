using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
