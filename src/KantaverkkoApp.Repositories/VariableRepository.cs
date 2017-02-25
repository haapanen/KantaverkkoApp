using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KantaverkkoApp.DatabaseInitializer;
using KantaverkkoApp.DataModel;
using KantaverkkoApp.DataModel.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KantaverkkoApp.Repositories
{
    public class VariableRepository : IVariableRepository
    {
        private readonly KantaverkkoAppContext _kantaverkkoAppContext;

        public VariableRepository(KantaverkkoAppContext kantaverkkoAppContext)
        {
            _kantaverkkoAppContext = kantaverkkoAppContext;
        }

        public Variable GetVariableForType(VariableType type)
        {
            return _kantaverkkoAppContext.Variables.FirstOrDefault(x => x.Type == type);
        }

        public IList<Variable> GetVariables()
        {
            return _kantaverkkoAppContext.Variables.ToList();
        }

        public IList<Event> GetEventsForVariable(VariableType type, DateTime startTime, DateTime endTime)
        {
            return _kantaverkkoAppContext
                .Variables
                .Include(x => x.Events)
                .FirstOrDefault(x => x.Type == type).Events.Where(x => x.StartTime >= startTime && x.EndTime < endTime).ToList();
        }

        public Event GetLatestEvent(VariableType type)
        {
            return _kantaverkkoAppContext.Events.OrderByDescending(x => x.EndTime).FirstOrDefault();
        }

        public void Save(Variable variable)
        {
            _kantaverkkoAppContext.Variables.Update(variable);
            _kantaverkkoAppContext.SaveChanges();
        }
    }
}
