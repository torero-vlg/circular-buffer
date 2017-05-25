using Newtonsoft.Json;

namespace AsteriskApiTest.JsonWorkerAssembly.Filters
{
    /// <summary>
    /// Фильтр запроса
    /// </summary>
    public class BaseFilterContext
    {
        /// <summary>
        /// Ограничение количества возвращаемых записей
        /// </summary>
        [JsonProperty("limit")]
        //[JsonIgnore]
        public int Limit { get; set; }
    }
}
