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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Scheduler.Models;

    public static class ExtensionMethods
    {
        /// <summary>
        /// TimeSpan extension to Convert TimeSpan to RecurrenceFrequency.
        /// </summary>
        /// <param name="timespan">TimeSpan to convert to frequency.</param>
        /// <returns>RecurrenceFrequency.</returns>
        public static RecurrenceFrequency GetFrequency(this TimeSpan timespan)
        {
            var frequency = RecurrenceFrequency.Hour;

            if(timespan.Minutes > 0)
            {
                frequency = RecurrenceFrequency.Minute;
            }

            return frequency;
        }

        /// <summary>
        /// TimeSpan extension to convert TimeSpan to Interval.
        /// </summary>
        /// <param name="timespan">TimeSpan to convert to interval.</param>
        /// <returns>Interval.</returns>
        public static int GetInterval(this TimeSpan timespan)
        {
            int interval = 1;

            if(timespan.Hours > 0)
            {
                interval = timespan.Hours;
            } else if(timespan.Minutes > 0)
            {
                interval = timespan.Minutes;
            }

            return interval;
        }

        /// <summary>
        /// DateTime extenstion to add weeks.
        /// </summary>
        /// <param name="time">Time in DateTime.</param>
        /// <param name="weeks">Number of weeks to add.</param>
        /// <returns>DateTime object.</returns>
        public static DateTime AddWeeks(this DateTime time, int weeks)
        {
            return time.AddDays(weeks * 7);
        }

        /// <summary>
        /// ICollection extension that adds the elements of the specified source list to end of the target collection.
        /// </summary>
        /// <typeparam name="T">Generic collection.</typeparam>
        /// <param name="target">To target where source list should be added to.</param>
        /// <param name="source">Elements to copy.</param>
        public static void AddRange<T>(this ICollection<T> target, IEnumerable<T> source)
        {
            if (target == null)
            {
                throw new ArgumentNullException(paramName: "target");
            }

            if (source == null)
            {
                throw new ArgumentNullException(paramName: "source");
            }

            foreach (var element in source)
            {
                target.Add(element);
            }
        }

        /// <summary>
        /// Hashtable extension to convert Hashtable to Dictionary.
        /// </summary>
        /// <param name="hashTable">Hashtable contents.</param>
        /// <returns>Converted Dictionary object.</returns>
        public static Dictionary<string, string> ToDictionary(this Hashtable hashTable)
        {
            return hashTable.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());
        }

        /// <summary>
        /// IDictionary extension to check whether a given key exist in the dictionary.
        /// </summary>
        /// <param name="dictionary">Dictionary contents.</param>
        /// <param name="key">Name of the key.</param>
        /// <returns>True, if key exists, false otherwise.</returns>
        public static bool ContainsKeyInvariantCultureIgnoreCase(this IDictionary<string,string> dictionary, string key)
        {
            foreach (var kvp in dictionary)
            {
                if (kvp.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// String extension that returns default value if target value is null or empty.
        /// </summary>
        /// <param name="targetValue">Target string value.</param>
        /// <param name="defaultValue">Default string value.</param>
        /// <returns>defaultValue if targetValue is null or empty, targetValue otherwise.</returns>
        public static string GetValueOrDefault(this string targetValue, string defaultValue)
        {
            return string.IsNullOrWhiteSpace(targetValue) ?  defaultValue : targetValue;
        }

        /// <summary>
        /// String extension that converts string to Enum.
        /// </summary>
        /// <typeparam name="T">Enum generic type.</typeparam>
        /// <param name="targetValue">staring taretValue.</param>
        /// <param name="defaultValue">defaultValue Enum.</param>
        /// <returns>defaultValue if targetValue is null or empty, targetValue Enum otherwise.</returns>
        public static T GetValueOrDefaultEnum<T>(this string targetValue, T defaultValue)
        {
            if(typeof(T).BaseType.FullName != "System.Enum" &&
               typeof(T).BaseType.FullName != "System.ValueType")
            {
                throw new ArgumentException("Type must be an Enum.");
            }

            if(string.IsNullOrWhiteSpace(targetValue))
            {
                return defaultValue;
            }
            
            if(typeof(T).BaseType.FullName == "System.ValueType")
            {
                return (T) Enum.Parse(Nullable.GetUnderlyingType(typeof(T)), targetValue, ignoreCase: true);
            }

            return (T)Enum.Parse(typeof(T), targetValue, ignoreCase: true);
        }

        /// <summary>
        /// PSCmdlet extension to resolve path.
        /// </summary>
        /// <param name="psCmdlet">Powershell cmdlet.</param>
        /// <param name="path">path.</param>
        /// <returns>Resolved PowerShell path.</returns>
        public static string ResolvePath(this PSCmdlet psCmdlet, string path)
        {
            if (path == null)
            {
                return null;
            }

            if (psCmdlet.SessionState == null)
            {
                return path;
            }

            path = path.Trim('"', '\'', ' ');
            var result = psCmdlet.SessionState.Path.GetResolvedPSPathFromPSPath(path);
            string fullPath = string.Empty;

            if (result != null && result.Count > 0)
            {
                fullPath = result[0].ProviderPath;
            }

            return fullPath;
        }
    }
}
