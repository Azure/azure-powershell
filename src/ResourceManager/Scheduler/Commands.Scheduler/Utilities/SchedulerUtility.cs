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

namespace Microsoft.Azure.Commands.Scheduler.Utilities
{
    using System;
    using System.Management.Automation;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Azure.Management.Scheduler.Models;

    public static class SchedulerUtility
    {
        /// <summary>
        /// Converts RecurrencyFrequecy and Interval to TimeSpan.
        /// </summary>
        /// <param name="frequency">RecurrenceFrequency.</param>
        /// <param name="interval">Interval.</param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(RecurrenceFrequency frequency, int interval)
        {
            DateTime epoch = DateTime.MinValue;

            switch (frequency)
            {
                case RecurrenceFrequency.Minute:
                    return epoch.AddMinutes(interval).Subtract(epoch);
                case RecurrenceFrequency.Hour:
                    return epoch.AddHours(interval).Subtract(epoch);
                case RecurrenceFrequency.Day:
                    return epoch.AddDays(interval).Subtract(epoch);
                case RecurrenceFrequency.Week:
                    return epoch.AddWeeks(interval).Subtract(epoch);
                case RecurrenceFrequency.Month:
                    return epoch.AddMonths(interval).Subtract(epoch);
                default:
                    throw new InvalidOperationException("Unsupported recurrence frequency.");
            }
        }

        /// <summary>
        /// Gets certificate data.
        /// </summary>
        /// <param name="pfxPath">Pfx location and name.</param>
        /// <param name="password">Pfx password.</param>
        /// <returns>Certificate data.</returns>
        public static string GetCertData(string pfxPath, string password)
        {
            if (!string.IsNullOrEmpty(pfxPath))
            {
                var cert = new X509Certificate2();
                cert.Import(pfxPath, password, X509KeyStorageFlags.Exportable);
                return cert.HasPrivateKey
                    ? Convert.ToBase64String(cert.Export(X509ContentType.Pfx, password))
                    : Convert.ToBase64String(cert.Export(X509ContentType.Pkcs12));
            }
            return null;
        }
    }
}
