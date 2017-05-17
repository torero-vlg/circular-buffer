using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace AsteriskApiTest.JsonWorkerAssembly
{
    public class JsonWorker
    {
        private readonly string _uriString;

        public JsonWorker(string uriString)
        {
            _uriString = uriString;
        }

        public WorkerResponse<T> Request<T>(RequestContext context)
        {
            var response = new WorkerResponse<T>();

            var req = WebRequest.Create(_uriString);
            req.Method = "POST";
            req.ContentType = "application/json";


            var reqString = "{" + $"\"service\":\"{context.Service}\",\"method\":\"{context.Method}\",\"object\":\"{context.Object}\"" + "}";

            var ms = new MemoryStream();

            var writer = new StreamWriter(
            ms);
            writer.Write(reqString);
            writer.Flush();

            ms.Position = 0;

            req.ContentLength = ms.Length;


            ms.CopyTo(
                req.GetRequestStream());

            var respStream = req.GetResponse().GetResponseStream();

            var jsonString = "";
            using (var reader = new StreamReader(respStream))
            {
                jsonString = reader.ReadToEnd();
                Console.WriteLine(jsonString);

            }
            Console.WriteLine("Hello World!");

            response = JsonConvert.DeserializeObject<WorkerResponse<T>>(jsonString);

            

            Console.WriteLine("Press any key to continue . . . ");

            return response;
        }
    }
}
