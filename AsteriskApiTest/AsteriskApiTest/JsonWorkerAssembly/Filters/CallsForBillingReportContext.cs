using System;
using Newtonsoft.Json;

namespace AsteriskApiTest.JsonWorkerAssembly.Filters
{
    /// <summary>
    /// Фильтр конкретного запроса CallsForBillingReportContext
    /// </summary>
    public class CallsForBillingReportContext : BaseFilterContext
    {
        [JsonProperty("dateMin")]
        public DateTime TimeStampFrom { get; set; }

        [JsonProperty("dateMax")]
        public DateTime TimeStampTo { get; set; }
    }
}
