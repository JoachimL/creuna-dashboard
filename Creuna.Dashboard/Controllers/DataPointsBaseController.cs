using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Http;
using Creuna.Dashboard.Entities;
using Creuna.Dashboard.Models;
using Creuna.Dashboard.Repositories;

namespace Creuna.Dashboard.Controllers
{
    public class DataPointsBaseController<T> : ApiController
    {
        private readonly IDataPointStore _dataPointStore;

        public DataPointsBaseController(IDataPointStore dataPointStore)
        {
            _dataPointStore = dataPointStore;
        }

        [Route("")]
        [HttpPost]
        public void Post([Required]DataPointPostModel<T> dataPoint)
        {
            if (ModelState.IsValid)
                StoreDataPoint(dataPoint);
        }

        private void StoreDataPoint(DataPointPostModel<T> dataPoint)
        {
            _dataPointStore.StoreDataPoint(new DataPoint<bool>
            {
                PartitionKey = dataPoint.Key,
                RowKey = Guid.NewGuid().ToString(),
                Value = dataPoint.Value
            });
        }
    }
}
