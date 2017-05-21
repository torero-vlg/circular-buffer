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
        /// Завершенны звонки
        /// </summary>
        public DataTable GetCompleteRings(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Завершенны звонки
        /// </summary>
        public DataTable GetCompleteRingsByKeyList(string keysList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Текущие звонки
        /// </summary>
        public DataTable GetCurrentRings()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Текущий звонок 
        /// </summary>
        /// <param name="num_from">Номер</param>
        public DataTable GetCurrentRing(string num_to)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Текущий звонок если не сработал обычный алгоритм
        /// по идее это такой звонок к-й был пропущен
        /// </summary>
        /// <param name="num_to"></param>
        /// <returns></returns>
        public DataTable GetCurrentRingIfMissed(string num_to)
        {
            throw new NotImplementedException();
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

        public DataTable ReportByOperators(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public DataTable GetActivitiPeers(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public DataTable GetOperatorsNotTacker(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public DataTable GetCallCenterAnaliticalIndexes(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public void SetQueueTimeout(long seconds)
        {
            throw new NotImplementedException();
        }
    }
}
