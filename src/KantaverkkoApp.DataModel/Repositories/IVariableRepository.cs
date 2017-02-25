using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantaverkkoApp.DataModel.Repositories
{
    public interface IVariableRepository
    {
        Variable GetVariableForType(VariableType type);
        IList<Variable> GetVariables();
        IList<Event> GetEventsForVariable(VariableType type, DateTime startTime, DateTime endTime);
    }
}
