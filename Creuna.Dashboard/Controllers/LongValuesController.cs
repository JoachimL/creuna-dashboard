using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using Creuna.Dashboard.Entities;
using Creuna.Dashboard.Models;
using Creuna.Dashboard.Repositories;

namespace Creuna.Dashboard.Controllers
{
    [RoutePrefix("api/longvalues")]
    public class LongValuesController : DataPointsBaseController<long>
    {
        public LongValuesController(IDataPointStore dataPointStore)
            : base(dataPointStore)
        {

        }
    }
}