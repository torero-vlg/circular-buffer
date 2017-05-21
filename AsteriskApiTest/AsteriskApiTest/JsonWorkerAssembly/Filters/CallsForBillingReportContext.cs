using System;
using Newtonsoft.Json;

namespace AsteriskApiTest.JsonWorkerAssembly.Filters
{
    /// <summary>
    /// Фильтр для запроса активные звонки
    /// </summary>
    public class ActiveRingContext : BaseFilterContext
    {
        [JsonProperty("dateMin")]
        public DateTime TimeStampFrom { get; set; }

        [JsonProperty("dateMax")]
        public DateTime TimeStampTo { get; set; }
    }
}
