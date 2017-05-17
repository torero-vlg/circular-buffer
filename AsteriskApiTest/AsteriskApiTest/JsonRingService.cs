using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AsteriskApiTest
{
    public class JsonRingService : IRingsService
    {
        private readonly string _uriString;

        public JsonRingService(string uriString)
        {
            _uriString = uriString;
        }

        public DataTable GetCallsForBillingReport(DateTime start, DateTime end)
        {
            var dt = new DataTable();


            var req = WebRequest.Create(_uriString);
            req.Method = "POST";
            req.ContentType = "application/json";
            var reqString = "{\"service\":\"storage\",\r\n\"method\":\"get\",\"object\":\"incallsring\"}";

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

            var jsonStr = "";
            using (var reader = new StreamReader(respStream))
            {
                jsonStr = reader.ReadToEnd();
                Console.WriteLine(jsonStr);

               // List<User> UserList = JsonConvert.DeserializeObject<List<User>>(jsonString);
            }
            Console.WriteLine("Hello World!");

            // TODO: Implement Functionality Here

            Console.WriteLine("Press any key to continue . . . ");

            return dt;
        }
    }
}
