// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    /// <summary>
    /// Some common helpers useful for the service client adapter layer
    /// </summary>
    public class CommonHelpers
    {
        /// <summary>
        /// Our service expects date time to be serialized in the following format
        /// we have to use english culture because our user might be running 
        /// PS in another culture and our service can't understand it.
        /// </summary>
        /// <param name="date">Input time</param>
        /// <returns>Output time in UTC</returns>
        public static string GetDateTimeStringForService(DateTime date)
        {
            DateTimeFormatInfo dateFormat = new CultureInfo("en-US").DateTimeFormat;
            return date.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss tt", dateFormat);
        }

        /// <summary>
        /// Backend service expects date time to be serialized 
        /// in the format: yyyy-MM-dd hh:mm:ss tt and en-US culture.
        /// In order to support user experiences from other time zones and cultures,
        /// this utility converts the date time into the correct date time format and culture.
        /// </summary>
        /// <param name="date">Input time</param>
        /// <returns>Output time in UTC as a DateTime object</returns>
        public static DateTime GetDateTimeForService(DateTime date)
        {
            DateTimeFormatInfo dateFormat = new CultureInfo("en-US").DateTimeFormat;
            string sDate = GetDateTimeStringForService(date);
            return DateTime.ParseExact(sDate, "yyyy-MM-dd hh:mm:ss tt", dateFormat);
        }
    }
}
