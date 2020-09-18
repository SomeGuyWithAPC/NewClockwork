﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrentTimeController : Controller
    {
      
        [HttpGet]
        public IActionResult Get(string zoneId = null)
        {
            var utcTime = DateTime.UtcNow;
            var serverTime = DateTime.Now;
            TimeZoneInfo timeZoneInfo = string.IsNullOrEmpty(zoneId)
                            ? null
                            : TimeZoneInfo.FindSystemTimeZoneById(zoneId);
            var requestedTimeZone = timeZoneInfo;

          
            var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();

            var returnVal = new CurrentTimeQuery
            {
                UTCTime = utcTime,
                ClientIp = ip,
                Time = requestedTimeZone == null
                    ? serverTime
                    : TimeZoneInfo.ConvertTimeFromUtc(utcTime, requestedTimeZone),
                ZoneId = zoneId
            };
             //List<string> TimeQuery = new List<string>();
             using (var db = new ClockworkContext())
            {
                db.CurrentTimeQueries.Add(returnVal);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                foreach (var CurrentTimeQuery in db.CurrentTimeQueries)
                {
                   Console.WriteLine($" - {CurrentTimeQuery.UTCTime}");
                   
                    //TimeQuery.Add(CurrentTimeQuery.UTCTime.ToString());
                }
                
            }
            return Ok(returnVal);

        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
           
            var result = new CurrentTimeQuery[0];

            using (var db = new ClockworkContext())
            {
                result = db.CurrentTimeQueries.ToArray();
            }

            Console.WriteLine();
            Console.WriteLine("{0} records in this database", result.Length);

            return Ok(result);
        }
    }
}
