using Newtonsoft.Json;

namespace AsteriskApiTest.JsonWorkerAssembly.Filters
{
    /// <summary>
    /// Фильтр для запроса текущий звонок
    /// </summary>
    public class CurrentRingContext : BaseFilterContext
    {
        [JsonProperty("num_to")]
        public string NumTo { get; set; }
    }
}
