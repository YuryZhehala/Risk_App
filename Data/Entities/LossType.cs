using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    
    public class LossType
    {
        public int LossTypeId { get; set; }
        public string LossTypeName { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
