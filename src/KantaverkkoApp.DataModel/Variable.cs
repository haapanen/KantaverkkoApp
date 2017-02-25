using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantaverkkoApp.DataModel
{
    public class Variable
    {
        public VariableType Type { get; set; }
        public string Unit { get; set; }
        public string DescriptionFin { get; set; }
        public string DescriptionEn { get; set; }
        public IList<Event> Events { get; set; }
    }
}
