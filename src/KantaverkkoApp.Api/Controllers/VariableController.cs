using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KantaverkkoApp.DataModel;
using KantaverkkoApp.DataModel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KantaverkkoApp.Api.Controllers
{
    [Route("api/variables")]
    public class VariableController : Controller
    {
        private readonly IVariableRepository _variableRepository;

        public VariableController(IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        [Route("")]
        [HttpGet]
        public IList<Variable> GetVariables()
        {
            return _variableRepository.GetVariables();
        }

        [Route("{type}")]
        [HttpGet]
        public Variable GetVariable(VariableType type)
        {
            return _variableRepository.GetVariableForType(type);
        }

        [Route("{type}/events")]
        [HttpGet]
        public IList<Event> GetEventsForVariable(VariableType type, DateTime startTime, DateTime endTime)
        {
            return
                _variableRepository.GetEventsForVariable(type, startTime, endTime);
        }
    }
}
