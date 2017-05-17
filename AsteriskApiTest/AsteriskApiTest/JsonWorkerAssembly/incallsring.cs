using System;
using Newtonsoft.Json;

namespace AsteriskApiTest.JsonWorkerAssembly
{
    public class IncallsRing
    {
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("timestart")]
        public DateTime? TimeStart { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("uniqueid")]
        public string UniqueId { get; set; }

        [JsonProperty("amounttime")]
        public int? AmountTime { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("num_to")]
        public string NumTo { get; set; }

        [JsonProperty("call_id")]
        public string CallId { get; set; }

        [JsonProperty("queue")]
        public string Queue { get; set; }

        [JsonProperty("num_from")]
        public string NumFrom { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
