using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantaverkkoApp.DataModel
{
    public class Event
    {
        public int Id { get; set; }
        public VariableType VariableType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Value { get; set; }
    }
}
