using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using Creuna.Dashboard.Entities;
using Creuna.Dashboard.Models;
using Creuna.Dashboard.Repositories;
using StructureMap.Query;

namespace Creuna.Dashboard.Controllers
{
    [RoutePrefix("api/booleans")]
    public class BooleansController : DataPointsBaseController<bool>
    {
        public BooleansController(IDataPointStore dataPointStore) : base(dataPointStore)
        {
            
        }
    }
}