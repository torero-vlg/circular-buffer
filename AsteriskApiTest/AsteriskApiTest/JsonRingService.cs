using System;
using System.Collections.Generic;
using System.Data;
using AsteriskApiTest.JsonWorkerAssembly;
using AsteriskApiTest.JsonWorkerAssembly.Filters;
using AsteriskApiTest.JsonWorkerAssembly.Models;

namespace AsteriskApiTest
{
    public class JsonRingService : IRingsService
    {
        private readonly string _uriString;

        public JsonRingService(string uriString)
        {
            _uriString = uriString;
        }

        /// <summary>
        /// Данные для отчета по стоимости разговоров
        /// </summary>
        public DataTable GetCallsForBillingReport(DateTime start, DateTime end)
        {
            var jsonWorker = new JsonWorker(_uriString);

            var context = new RequestContext<CallsForBillingReportContext>
            {
                Service = "storage",
                Method = "get",
                Object = "incallsring",
                FilterContext = new CallsForBillingReportContext { TimeStampFrom = start, TimeStampTo = end, Limit = 100}
            };

            var response = jsonWorker.Request<List<IncallsRingResponse>, CallsForBillingReportContext>(context);

            //преобразовать response.Result в DataTable
            return response.Result.ToDataTable();
        }
    }
}
