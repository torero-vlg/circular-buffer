/*
 * Created by SharpDevelop.
 * User: user
 * Date: 12.05.2017
 * Time: 3:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;

namespace AsteriskApiTest
{
	class Program
	{
        public static void Main(string[] args)
        {
            var service = new JsonRingService("http://192.168.30.212:8081/http");
            var dataTable = service.GetCallsForBillingReport(DateTime.Today.AddMonths(-1), DateTime.Today);

            Console.WriteLine($"Rows count = {dataTable.Rows.Count}");
            Console.ReadLine();
        }

        //      public static void Main(string[] args)
        //{

        //	var req = WebRequest.Create("http://192.168.30.212:8081/http");
        //	req.Method = "POST";
        //	req.ContentType = "application/json";
        //	var reqString = "{\"service\":\"storage\",\r\n\"method\":\"get\",\"object\":\"incallsring\"}";

        //	var ms = new MemoryStream();

        //	var writer = new StreamWriter(
        //	ms);
        //	writer.Write(reqString);
        //	writer.Flush();

        //	ms.Position = 0;

        //	req.ContentLength = ms.Length;		


        //	ms.CopyTo(
        //		req.GetRequestStream());

        //	var respStream = req.GetResponse().GetResponseStream();

        //          var jsonStr = "";
        //          using (var reader = new StreamReader(respStream))
        //          {
        //              jsonStr = reader.ReadToEnd();
        //              Console.WriteLine(jsonStr);

        //              List<User> UserList = JsonConvert.DeserializeObject<List<User>>(jsonString);
        //          }
        //	Console.WriteLine("Hello World!");

        //	// TODO: Implement Functionality Here

        //	Console.Write("Press any key to continue . . . ");
        //	Console.ReadKey(true);
        //}

    }
}