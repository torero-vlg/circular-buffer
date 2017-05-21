using Newtonsoft.Json;

namespace AsteriskApiTest.JsonWorkerAssembly.Filters
{
    /// <summary>
    /// Фильтр конкретного запроса CurrentRingIfMissedContext
    /// </summary>
    public class CurrentRingIfMissedContext : BaseFilterContext
    {
        [JsonProperty("num_to")]
        public string NumTo { get; set; }
    }
}
