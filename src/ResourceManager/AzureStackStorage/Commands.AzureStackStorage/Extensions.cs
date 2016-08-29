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


using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    internal static class Extensions
    {
        public static string FormatInvariantCulture(this string format, params object[] arg0)
        {
            return string.Format(CultureInfo.InvariantCulture, format, arg0);
        }

        /// <summary>
        /// A string representation of the list of MetricAvailability objects including indentation
        /// </summary>
        /// <param name="metricAvailabilities">The list of MetricAvailability objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of MetricAvailability objects including indentation</returns>
        public static string ToString(this IList<MetricAvailability> metricAvailabilities, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            foreach (var metricAvailability in metricAvailabilities)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Retention : " + metricAvailability.Retention);
                output.AddSpacesInFront(indentationTabs).Append("Values    : " + metricAvailability.TimeGrain);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the list of PSMetricValue objects including indentation
        /// </summary>
        /// <param name="metricValues">The list of PSMetricValue objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of PSMetricValue objects including indentation</returns>
        public static string ToString(this IList<MetricValue> metricValues, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            foreach (var metricValue in metricValues)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Average    : " + metricValue.Average);
                output.AddSpacesInFront(indentationTabs).AppendLine("Count      : " + metricValue.Count);
                output.AddSpacesInFront(indentationTabs).AppendLine("Maximum    : " + metricValue.Maximum);
                output.AddSpacesInFront(indentationTabs).AppendLine("Minimum    : " + metricValue.Minimum);
                output.AddSpacesInFront(indentationTabs).AppendLine("Properties : " + metricValue.Properties);
                output.AddSpacesInFront(indentationTabs).AppendLine("Timestamp  : " + metricValue.TimeStamp);
                output.AddSpacesInFront(indentationTabs).Append("Total      : " + metricValue.Total);
            }
            return output.ToString();
        }

        /// <summary>
        /// Add spaces into the string builder
        /// </summary>
        /// <param name="output">The string builder</param>
        /// <param name="indentationTabs">The number of tab chars to insert</param>
        /// <returns>The input string builder with the tabs appended</returns>
        public static StringBuilder AddSpacesInFront(this StringBuilder output, int indentationTabs)
        {
            for (int i = 0; i < indentationTabs; i++)
            {
                output.Append('\t');
            }

            return output;
        }
    }
}
