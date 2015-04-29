using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Creuna.Dashboard.Entities;
using Creuna.Dashboard.ViewModels;

namespace Creuna.Dashboard.Controllers
{
    [RoutePrefix("api/datapoints")]
    public class DataPointsController : ApiController
    {
        private static int coffeeCups = 17;
        private static bool friday;

        [Route("{key}")]
        public DataPointViewModel Get(string key)
        {
            if (key == "coffee")
                return new CounterViewModel(key, DateTime.UtcNow, coffeeCups++);
            if (key == "isitfriday")
            {
                friday = !friday;
                return new BooleanViewModel(key, DateTime.UtcNow, friday);
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

            //[Route("")]
            //public IEnumerable<DataPoint
    }
}