using Newtonsoft.Json;

namespace AsteriskApiTest.JsonWorkerAssembly
{
    /// <summary>
    /// Контекст ответа
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseContext<T>
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("result")]
        public string ResultCode { get; set; }


        //TODO проблема: имя этого атрибута динамическое, соответствует значению this.Object
        [JsonProperty("incallsring")]
        public T Result { get; set; }
    }
}
