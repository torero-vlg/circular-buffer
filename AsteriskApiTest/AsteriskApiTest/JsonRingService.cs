using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using AsteriskApiTest.JsonWorkerAssembly;

namespace AsteriskApiTest
{
    public class JsonRingService : IRingsService
    {
        private readonly string _uriString;

        public JsonRingService(string uriString)
        {
            _uriString = uriString;
        }

        public DataTable GetCallsForBillingReport(DateTime start, DateTime end)
        {
            var jsonWorker = new JsonWorker(_uriString);

            var context = new RequestContext
            {
                Service = "storage",
                Method = "get",
                Object = "incallsring"
            };

            var response = jsonWorker.Request<List<IncallsRing>>(context);

            //преобразовать response.Result в DataTable
            return response.Result.ToDataTable();
        }
    }
}
