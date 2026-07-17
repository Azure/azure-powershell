/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json
{
    internal struct IsoDate
    {
        internal int Year { get; set; }           // 0-3000

        internal int Month { get; set; }          // 1-12

        internal int Day { get; set; }            // 1-31

        internal int Hour { get; set; }           // 0-24

        internal int Minute { get; set; }         // 0-60 (60 is a special case)

        internal int Second { get; set; }         // 0-60 (60 is used for leap seconds)

        internal double Millisecond { get; set; } // 0-999.9...

        internal TimeSpan Offset { get; set; }

        internal DateTimeKind Kind { get; set; }

        internal TimeSpan TimeOfDay => new TimeSpan(Hour, Minute, Second);

        internal DateTime ToDateTime()
        {
            if (Kind == DateTimeKind.Utc || Offset == TimeSpan.Zero)
            {
                return new DateTime(Year, Month, Day, Hour, Minute, Second, (int)Millisecond, DateTimeKind.Utc);
            }

            return ToDateTimeOffset().DateTime;
        }

        internal DateTimeOffset ToDateTimeOffset()
        {
            return new DateTimeOffset(
                Year,
                Month,
                Day,
                Hour,
                Minute,
                Second,
                (int)Millisecond,
                Offset
            );
        }

        internal DateTime ToUtcDateTime()
        {
            return ToDateTimeOffset().UtcDateTime;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            // yyyy-MM-dd
            sb.Append($"{Year}-{Month:00}-{Day:00}");

            if (TimeOfDay > new TimeSpan(0))
            {
                sb.Append($"T{Hour:00}:{Minute:00}");

                if (TimeOfDay.Seconds > 0)
                {
                    sb.Append($":{Second:00}");
                }
            }

            if (Offset.Ticks == 0)
            {
                sb.Append('Z'); // UTC
            }
            else
            {
                if (Offset.Ticks >= 0)
                {
                    sb.Append('+');
                }

                sb.Append($"{Offset.Hours:00}:{Offset.Minutes:00}");
            }

            return sb.ToString();
        }

        internal static IsoDate FromDateTimeOffset(DateTimeOffset date)
        {
            return new IsoDate {
                Year   = date.Year,
                Month  = date.Month,
                Day    = date.Day,
                Hour   = date.Hour,
                Minute = date.Minute,
                Second = date.Second,
                Offset = date.Offset,
                Kind   = date.Offset == TimeSpan.Zero ? DateTimeKind.Utc : DateTimeKind.Unspecified
            };
        }

        private static readonly char[] timeSeperators = { ':', '.' };

        internal static IsoDate Parse(string text)
        {
            var tzIndex = -1;
            var timeIndex = text.IndexOf('T');

            var builder = new IsoDate { Day = 1, Month = 1 };

            // TODO: strip the time zone offset off the end
            string dateTime = text;
            string timeZone = null;

            if (dateTime.IndexOf('Z') > -1)
            {
                tzIndex = dateTime.LastIndexOf('Z');

                builder.Kind = DateTimeKind.Utc;
            }
            else if (dateTime.LastIndexOf('+') > 10)
            {
                tzIndex = dateTime.LastIndexOf('+');
            }
            else if (dateTime.LastIndexOf('-') > 10)
            {
                tzIndex = dateTime.LastIndexOf('-');
            }

            if (tzIndex > -1)
            {
                timeZone = dateTime.Substring(tzIndex);
                dateTime = dateTime.Substring(0, tzIndex);
            }

            string date = (timeIndex == -1) ? dateTime : dateTime.Substring(0, timeIndex);

            var dateParts = date.Split(Seperator.Dash); // '-'

            for (int i = 0; i < dateParts.Length; i++)
            {
                var part = dateParts[i];

                switch (i)
                {
                    case 0: builder.Year = int.Parse(part); break;
                    case 1: builder.Month = int.Parse(part); break;
                    case 2: builder.Day = int.Parse(part); break;
                }
            }

            if (timeIndex > -1)
            {
                string[] timeParts = dateTime.Substring(timeIndex + 1).Split(timeSeperators);

                for (int i = 0; i < timeParts.Length; i++)
                {
                    var part = timeParts[i];

                    switch (i)
                    {
                        case 0: builder.Hour        = int.Parse(part); break;
                        case 1: builder.Minute      = int.Parse(part); break;
                        case 2: builder.Second      = int.Parse(part); break;
                        case 3: builder.Millisecond = double.Parse("0." + part) * 1000; break;
                    }
                }
            }

            if (timeZone != null && timeZone != "Z")
            {
                var hours = int.Parse(timeZone.Substring(1, 2));
                var minutes = int.Parse(timeZone.Substring(4, 2));

                if (timeZone[0] == '-')
                {
                    hours = -hours;
                    minutes = -minutes;
                }

                builder.Offset = new TimeSpan(hours, minutes, 0);
            }

            return builder;
        }
    }

    /*  
	YYYY						# eg 1997
	YYYY-MM						# eg 1997-07
	YYYY-MM-DD					# eg 1997-07-16
	YYYY-MM-DDThh:mmTZD			# eg 1997-07-16T19:20+01:00
	YYYY-MM-DDThh:mm:ssTZD		# eg 1997-07-16T19:20:30+01:00
	YYYY-MM-DDThh:mm:ss.sTZD	# eg 1997-07-16T19:20:30.45+01:00

	where:

	YYYY = four-digit year
	MM   = two-digit month (01=January, etc.)
	DD   = two-digit day of month (01 through 31)
	hh   = two digits of hour (00 through 23) (am/pm NOT allowed)
	mm   = two digits of minute (00 through 59)
	ss   = two digits of second (00 through 59)
	s    = one or more digits representing a decimal fraction of a second
	TZD  = time zone designator (Z or +hh:mm or -hh:mm)
	*/
}
