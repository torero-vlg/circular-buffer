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
            var jsonWorker = new JsonWorker(_uriString);

            var context = new RequestContext<CurrentRingIfMissedContext>
            {
                Service = "storage",//TODO уточнить название сервиса
                Method = "get",
                Object = "incallsring",//TODO уточнить название
                FilterContext = new CurrentRingIfMissedContext { NumTo = num_to }
            };

            var response = jsonWorker.Request<List<IncallsRingResponse>, CurrentRingIfMissedContext>(context);

            //преобразовать response.Result в DataTable
            var resultDataTable = response.Result.ToDataTable();

            return MapRingDirection(resultDataTable);
        }

        /// <summary>
        /// Данные для отчета по стоимости разговоров
        /// </summary>
        public DataTable GetCallsForBillingReport(DateTime start, DateTime end)
        {
            var jsonWorker = new JsonWorker(_uriString);

            var context = new RequestContext<CallsForBillingReportContext>
            {
                Service = "storage",//TODO уточнить название сервиса
                Method = "get",
                Object = "incallsring",//TODO уточнить название
                FilterContext = new CallsForBillingReportContext { TimeStampFrom = start, TimeStampTo = end, Limit = 1000 }//TODO должно будет работать без лимита
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

        /// <summary>
        /// Проставить статус в таблице
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private DataTable MapRingStatus(DataTable dataTable)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("0", "Пропущен");
            map.Add("1", "Текущий");
            map.Add("2", "Без заказа");
            map.Add("3", "Не отвечен");

            foreach (DataRow row in dataTable.Rows)
            {
                string status = row["status"].ToString();

                if (map.ContainsKey(status))
                    row["status_str"] = map[status];
                else
                    row["status_str"] = "Не определен";
            }

            return dataTable;
        }

        /// <summary>
        /// Проставить тип звонка в таблице
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private DataTable MapRingDirection(DataTable dataTable)
        {
            var map = new Dictionary<string, string>();
            map.Add("in", "Входящий");
            map.Add("out", "Исходящий");

            foreach (DataRow row in dataTable.Rows)
            {
                string direction = row["direction"].ToString();

                if (map.ContainsKey(direction))
                    row["direction"] = map[direction];
            }

            return dataTable;
        }
    }
}
