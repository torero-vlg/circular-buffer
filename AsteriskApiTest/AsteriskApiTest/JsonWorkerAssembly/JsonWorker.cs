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

        public ResponseContext<TResult> Request<TResult, TFilter>(RequestContext<TFilter> context) 
            where TFilter : BaseFilterContext
            where TResult : new()
        {
            var filter = JsonConvert.SerializeObject(context.FilterContext, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });

            var requestString = 
                "{" + 
                string.Format("\"service\":\"{0}\",", context.Service) +
                string.Format("\"method\":\"{context.Method}\",", context.Service) +
                string.Format("\"object\":\"{context.Object}\",", context.Service) +
                string.Format("\"{context.Object}\":{filter}", context.Service) + 
                "}";
            _logger.Debug(requestString);
            var ms = new MemoryStream();

            var writer = new StreamWriter(ms);
            writer.Write(requestString);
            writer.Flush();

            ms.Position = 0;

            var req = WebRequest.Create(_uriString);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = ms.Length;

            ms.CopyTo(req.GetRequestStream());

            Stream respStream;
            try
            {
                respStream = req.GetResponse().GetResponseStream();
            }
            catch (Exception ex)
            {
                throw new Exception("Произошла ошибка при выполнении  запроса", ex);
            }

            string jsonString;
            using (var reader = new StreamReader(respStream))
            {
                jsonString = reader.ReadToEnd();
                _logger.Trace(jsonString);
            }

            var response = new ResponseContext<TResult>();

            try
            {
                response = JsonConvert.DeserializeObject<ResponseContext<TResult>>(jsonString);
            }
            catch (Exception ex)
            {
                //десериализуем ошибочный ответ
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponseContext>(jsonString);

                switch (errorResponse.ResultCode)
                {
                    //не найдено результатов
                    case 404:
                        {
                            response.Object = errorResponse.Object;
                            response.Reason = errorResponse.Reason;
                            response.Service = errorResponse.Service;
                            response.Result = new TResult();
                            response.Method = errorResponse.Method;
                            break;
                        }
                    default:
                        throw new Exception(string.Format("{0} {1}", errorResponse.Error, errorResponse.Description));
                }
            }

            return response;
        }
    }
}
