﻿/*
 * Created by SharpDevelop.
 * User: user
 * Date: 12.05.2017
 * Time: 3:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using NLog;

namespace AsteriskApiTest
{
	class Program
	{
        public static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            var service = new JsonRingService("http://192.168.30.212:8081/http");

            var start = new DateTime(2017, 8, 1, 18, 0, 0);
            var end = new DateTime(2016, 10, 20, 18, 0, 0);

            var dataTable = service.GetCallsForBillingReport(start, end);

            logger.Warn($"DataTable Rows count = {dataTable.Rows.Count}");

            //Console.ReadLine();
        }
    }
}