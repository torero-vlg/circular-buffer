using Newtonsoft.Json;

namespace AsteriskApiTest.JsonWorkerAssembly
{
    /// <summary>
    /// Класс для обработки ответа ошибочного запроса
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ErrorResponseContext : ResponseContext<object>
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
