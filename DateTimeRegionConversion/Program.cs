// See https://aka.ms/new-console-template for more information
// https://learn.microsoft.com/en-us/dotnet/api/system.timezoneinfo.getsystemtimezones?view=net-7.0
// https://learn.microsoft.com/en-us/globalization/locale/time-formatting-and-time-zones-in-dotnet-framework
// https://learn.microsoft.com/en-us/dotnet/api/system.timezoneinfo.findsystemtimezonebyid?source=recommendations&view=net-7.0
// https://learn.microsoft.com/en-us/dotnet/standard/datetime/access-utc-and-local
// https://learn.microsoft.com/en-us/dotnet/standard/datetime/finding-the-time-zones-on-local-system
// https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset?view=net-7.0


// Shaun's Stuff
// See https://aka.ms/new-console-template for more information
//
var localTime = DateTime.Parse("2021-02-01 00:00:00");
var tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
var batchTime = TimeZoneInfo.ConvertTimeToUtc(localTime, tz);
Console.WriteLine("Timestamp        : {0}", localTime);
Console.WriteLine("EST              : {0}", tz);
Console.WriteLine("Daylight saving  : {0}", tz.IsDaylightSavingTime(localTime));
Console.WriteLine("Batch time UTC   : {0}", batchTime.ToUniversalTime());
Console.WriteLine("Batch time Local : {0}", batchTime.ToLocalTime());

/*
    Do this when scheduling...
    batch time to universal time will give equiv time UTC when you want to run this.
    - ScheduleFor
    - SuspendOn
    are the two dates you want to do this for when scheduling.
    SubscriptionCancelledOn - just UTC because it must show as 2022-01-01 00:00:00
*/

// ---------------------------------------------------------------------------------------------------------------------------------

// var saTime = DateTime.Parse("2021-03-03"); // DateTime.Now;
// var utcTime = TimeZoneInfo.ConvertTimeToUtc(saTime);
// var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
// var estTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, easternZone);

// Console.WriteLine($"UTC Time = {utcTime}, SA Time: {saTime}, EST Time = {estTime}");



// var utcTime =  TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2021-05-01 17:00:00"));
// var utcTime_1 =  DateTime.Parse("2021-05-01 17:00:00Z");
// var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
// var estTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, easternZone);

// Console.WriteLine($"UTC Time = {utcTime}, EST Time = {estTime}");

// var result = estTime - utcTime;
// Console.WriteLine(result);

// Console.WriteLine($"{utcTime} - {utcTime_1}");


// ----------------------------------------------------------------------------------------------------------------------
// var test = DateTime.Parse("2021-05-01 00:00:00");
// var res = test.ToUniversalTime();
// Console.WriteLine(res);


// var utcTime = DateTime.UtcNow;
// var utcTime_ = DateTime.Parse("2021-05-01 00:00:00Z");
// var utcTime_2 = DateTime.Parse("2021-05-01T00:00:00");
// var fancyTime = new DateTimeOffset(utcTime);
// var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
// // Batch Time = utcTime - easterZone.BaseUtcOffset
// var estTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, easternZone);

// Console.WriteLine($"UTC Time = {utcTime}, EST Time = {estTime}");

// var result = Math.Abs((estTime - utcTime).Hours);
// Console.WriteLine(result);

// Console.WriteLine($"{utcTime} - {utcTime_1}");

// ----------------------------------------------------------------------------------------------------------------------




// // Create Eastern Standard Time value and TimeZoneInfo object
// DateTime estTime = new DateTime(2007, 1, 1, 00, 00, 00);
// string timeZoneName = "Eastern Standard Time";
// try
// {
//    TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);

//    // Convert EST to local time
//    DateTime localTime = TimeZoneInfo.ConvertTime(estTime, est, TimeZoneInfo.Local);
//    Console.WriteLine("At {0} {1}, the local time is {2} {3}.",
//            estTime,
//            est,
//            localTime,
//            TimeZoneInfo.Local.IsDaylightSavingTime(localTime) ?
//                      TimeZoneInfo.Local.DaylightName :
//                      TimeZoneInfo.Local.StandardName);

//    // Convert EST to UTC
//    DateTime utcTime = TimeZoneInfo.ConvertTime(estTime, est, TimeZoneInfo.Utc);
//    Console.WriteLine("At {0} {1}, the time is {2} {3}.",
//            estTime,
//            est,
//            utcTime,
//            TimeZoneInfo.Utc.StandardName);
// }
// catch (TimeZoneNotFoundException)
// {
//    Console.WriteLine("The {0} zone cannot be found in the registry.",
//                      timeZoneName);
// }
// catch (InvalidTimeZoneException)
// {
//    Console.WriteLine("The registry contains invalid data for the {0} zone.",
//                      timeZoneName);
// }

// // The example produces the following output to the console:
// //    At 1/1/2007 12:00:00 AM (UTC-05:00) Eastern Time (US & Canada), the local time is 1/1/2007 12:00:00 AM Eastern Standard Time.
// //    At 1/1/2007 12:00:00 AM (UTC-05:00) Eastern Time (US & Canada), the time is 1/1/2007 5:00:00 AM UTC.



// using System;
// using System.Globalization;
// using System.IO;
// using System.Collections.ObjectModel;

// public class Example
// {
//    public static void Main()
//    {
//       const string OUTPUTFILENAME = @"C:\Code\TimeZoneInfo.txt";
   
//       DateTimeFormatInfo dateFormats = CultureInfo.CurrentCulture.DateTimeFormat;
//       ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones(); 
//       StreamWriter sw = new StreamWriter(OUTPUTFILENAME, false);
   
//       foreach (TimeZoneInfo timeZone in timeZones)
//       {
//          bool hasDST = timeZone.SupportsDaylightSavingTime;
//          TimeSpan offsetFromUtc = timeZone.BaseUtcOffset;
//          TimeZoneInfo.AdjustmentRule[] adjustRules;
//          string offsetString;
      
//          sw.WriteLine("ID: {0}", timeZone.Id);
//          sw.WriteLine("   Display Name: {0, 40}", timeZone.DisplayName);
//          sw.WriteLine("   Standard Name: {0, 39}", timeZone.StandardName);
//          sw.Write("   Daylight Name: {0, 39}", timeZone.DaylightName);
//          sw.Write(hasDST ? "   ***Has " : "   ***Does Not Have ");
//          sw.WriteLine("Daylight Saving Time***");
//          offsetString = String.Format("{0} hours, {1} minutes", offsetFromUtc.Hours, offsetFromUtc.Minutes);
//          sw.WriteLine("   Offset from UTC: {0, 40}", offsetString);
//          adjustRules = timeZone.GetAdjustmentRules();
//          sw.WriteLine("   Number of adjustment rules: {0, 26}", adjustRules.Length);  
//          if (adjustRules.Length > 0)
//          {
//             sw.WriteLine("   Adjustment Rules:");
//             foreach (TimeZoneInfo.AdjustmentRule rule in adjustRules)
//             {
//                TimeZoneInfo.TransitionTime transTimeStart = rule.DaylightTransitionStart;
//                TimeZoneInfo.TransitionTime transTimeEnd = rule.DaylightTransitionEnd; 
            
//                sw.WriteLine("      From {0} to {1}", rule.DateStart, rule.DateEnd);
//                sw.WriteLine("      Delta: {0}", rule.DaylightDelta);
//                if (! transTimeStart.IsFixedDateRule)
//                {
//                   sw.WriteLine("      Begins at {0:t} on {1} of week {2} of {3}", transTimeStart.TimeOfDay, 
//                                                                                 transTimeStart.DayOfWeek,                                                                                 
//                                                                                 transTimeStart.Week, 
//                                                                                 dateFormats.MonthNames[transTimeStart.Month - 1]);
//                   sw.WriteLine("      Ends at {0:t} on {1} of week {2} of {3}", transTimeEnd.TimeOfDay,
//                                                                                 transTimeEnd.DayOfWeek, 
//                                                                                 transTimeEnd.Week,
//                                                                                 dateFormats.MonthNames[transTimeEnd.Month - 1]);
//                }
//                else
//                {
//                   sw.WriteLine("      Begins at {0:t} on {1} {2}", transTimeStart.TimeOfDay, 
//                                                                  transTimeStart.Day, 
//                                                                  dateFormats.MonthNames[transTimeStart.Month - 1]);
//                   sw.WriteLine("      Ends at {0:t} on {1} {2}", transTimeEnd.TimeOfDay, 
//                                                                transTimeEnd.Day, 
//                                                                dateFormats.MonthNames[transTimeEnd.Month - 1]);
//                }
//             }
//          }            
//       }
//       sw.Close();
//    }
// }
