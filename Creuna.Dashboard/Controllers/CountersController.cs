using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Creuna.Dashboard.Repositories;

namespace Creuna.Dashboard.Controllers
{
    [RoutePrefix("/api/counters/")]
    public class CountersController : ApiController
    {
        private readonly IDataPointStore _dataPointStore;

        public CountersController(IDataPointStore dataPointStore)
        {
            _dataPointStore = dataPointStore;
        }

        [Route("{key}/{date}")]
        public void Update(string key)
        {
            _dataPointStore.IncrementCounter(key);
        }
    }
}