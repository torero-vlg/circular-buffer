using System;
using Newtonsoft.Json;

namespace AsteriskApiTest.JsonWorkerAssembly.Filters
{
    /// <summary>
    /// Фильтр запроса завершнные звонки
    /// </summary>
    public class CompleteRingContext : BaseFilterContext
    {
        [JsonProperty("keyList")]
        public string KeyList { get; set; }

        [JsonProperty("dateMin")]
        public DateTime? TimeStampFrom { get; set; }

        [JsonProperty("dateMax")]
        public DateTime? TimeStampTo { get; set; }
    }
}
