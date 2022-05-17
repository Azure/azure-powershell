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

using System.Collections.Generic;
using System.Linq;
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models
{
    public class Utilities 
    {
        internal static string[] ConvertToDocumentType(string[] recordTypes)
        {
            Dictionary<string, string> mapping = new Dictionary<string, string>();
            mapping.Add(RecordTypes.Requests.ToLowerInvariant(), DocumentTypes.Requests);
            mapping.Add(RecordTypes.Event.ToLowerInvariant(), DocumentTypes.Event);
            mapping.Add(RecordTypes.Exceptions.ToLowerInvariant(), DocumentTypes.Exceptions);
            mapping.Add(RecordTypes.Messages.ToLowerInvariant(), DocumentTypes.Messages);
            mapping.Add(RecordTypes.Metrics.ToLowerInvariant(), DocumentTypes.Metrics);
            mapping.Add(RecordTypes.PageViewPerformance.ToLowerInvariant(), DocumentTypes.PageViewPerformance);
            mapping.Add(RecordTypes.PageViews.ToLowerInvariant(), DocumentTypes.PageViews);
            mapping.Add(RecordTypes.RemoteDependency.ToLowerInvariant(), DocumentTypes.RemoteDependency);
            mapping.Add(RecordTypes.Availability.ToLowerInvariant(), DocumentTypes.Availability);
            mapping.Add(RecordTypes.PerformanceCounters.ToLowerInvariant(), DocumentTypes.PerformanceCounters);

            return recordTypes.Select(d => mapping[d.Trim().ToLowerInvariant()]).ToArray();
        }

        public static string ParseSubscriptionFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[1];
            }

            return null;
        }
    }

    public class ApplicationType
    {
        public const string WEB = "web";
        public const string JAVA = "java";
        public const string NodeJs = "Node.js";
        public const string General = "other";
    }

    public class DocumentTypes
    {
        public const string Requests = "Request";
        public const string Event = "Custom Event";
        public const string Exceptions = "Exception";
        public const string Metrics = "Metric";
        public const string PageViews = "Page View";
        public const string PageViewPerformance = "Page Load";
        public const string RemoteDependency = "Dependency";
        public const string PerformanceCounters = "Performance Counter";
        public const string Availability = "Availability";
        public const string Messages = "Trace";
    }

    internal class RecordTypes
    {
        public const string Requests = "Requests";
        public const string Event = "Event";
        public const string Exceptions = "Exceptions";
        public const string Metrics = "Metrics";
        public const string PageViews = "PageViews";
        public const string PageViewPerformance = "PageViewPerformance";
        public const string RemoteDependency = "Rdd";
        public const string PerformanceCounters = "PerformanceCounters";
        public const string Availability = "Availability";
        public const string Messages = "Messages";
    }

    public class PermissionType
    {
        public const string ReadTelemetry = "ReadTelemetry";
        public const string WriteAnnotations = "WriteAnnotations";
        public const string AuthenticateSDKControlChannel = "AuthenticateSDKControlChannel";
    }

    public class PricingPlans
    {
        public const string Basic = "Basic";
        public const string Enterprise = "Application Insights Enterprise";
        public const string LimitedBasic = "Limited Basic";
    }
}