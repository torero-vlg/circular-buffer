using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using AsteriskApiTest.JsonWorkerAssembly.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;

namespace AsteriskApiTest.JsonWorkerAssembly
{
    public class JsonWorker
    {
        private readonly string _uriString;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public JsonWorker(string uriString)
        {
            _uriString = uriString;
        }

        public ResponseContext<TResult> Request<TResult, TFilter>(RequestContext<TFilter> context) where TFilter : BaseFilterContext
        {
            var req = WebRequest.Create(_uriString);
            req.Method = "POST";
            req.ContentType = "application/json";

            var filter = JsonConvert.SerializeObject(context.FilterContext, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });

            var requestString = 
                "{" + 
                $"\"service\":\"{context.Service}\"," +
                $"\"method\":\"{context.Method}\"," +
                $"\"object\":\"{context.Object}\"," +
                $"\"{context.Object}\":{filter}" + 
                "}";
            _logger.Debug(requestString);
            var ms = new MemoryStream();

            var writer = new StreamWriter(ms);
            writer.Write(requestString);
            writer.Flush();

            ms.Position = 0;

            req.ContentLength = ms.Length;


            ms.CopyTo(req.GetRequestStream());

            var respStream = req.GetResponse().GetResponseStream();

            string jsonString;
            using (var reader = new StreamReader(respStream))
            {
                jsonString = reader.ReadToEnd();
                _logger.Trace(jsonString);
            }

            var response = JsonConvert.DeserializeObject<ResponseContext<TResult>>(jsonString);


            return response;
        }
    }
}
