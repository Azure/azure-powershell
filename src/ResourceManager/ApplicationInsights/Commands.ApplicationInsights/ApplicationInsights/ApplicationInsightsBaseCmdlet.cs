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

using Microsoft.Azure.Commands.ApplicationInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.ApplicationInsights.Management;
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.ApplicationInsights
{
    public abstract class ApplicationInsightsBaseCmdlet : AzureRMCmdlet
    {
        private ApplicationInsightsManagementClientWrapper appInsightsManagementClientWrapper;

        protected const string ApplicationInsightsNounStr = "AzureRmApplicationInsights";
        protected const string ApplicationInsightsPricingPlanNounStr = "AzureRmApplicationInsightsPricingPlan";
        protected const string ApplicationInsightsDailyCapNounStr = "AzureRmApplicationInsightsDailyCap";
        protected const string ApplicationInsightsDailyCapStatusNounStr = "AzureRmApplicationInsightsDailyCapStatus";
        protected const string ApplicationInsightsContinuousExportNounStr = "AzureRmApplicationInsightsContinuousExport";
        protected const string ApplicationInsightsApiKeyNounStr = "AzureRmApplicationInsightsApiKey";
        protected const string ApplicationInsightsComponentNameAlias = "ApplicationInsightsComponentName";
        protected const string ComponentNameAlias = "ComponentName";
        protected const string ApplicationKindAlias = "ApplicationKind";
        protected const string TagsAlias = "Tags";

        public class ApplicationType
        {
            public const string WEB = "web";
            public const string JAVA = "java";
            public const string NodeJs = "Node.js";
            public const string General = "other";
        }

        public class DocumentType
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

        internal class RecordType
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

        public IApplicationInsightsManagementClient AppInsightsManagementClient
        {
            get
            {
                if (appInsightsManagementClientWrapper == null)
                {
                    appInsightsManagementClientWrapper = new ApplicationInsightsManagementClientWrapper(DefaultProfile.DefaultContext)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp
                    };
                }

                return appInsightsManagementClientWrapper.appInsightsManagementClient;
            }

            set { appInsightsManagementClientWrapper = new ApplicationInsightsManagementClientWrapper(value); }
        }

        public string SubscriptionId
        {
            get
            {
                return DefaultProfile.DefaultContext.Subscription.Id.ToString();
            }
        }

        protected void WriteCurrentFeatures(ApplicationInsightsComponentBillingFeatures billing)
        {
            if (billing != null)
            {
                WriteObject(PSPricingTier.Create(billing));
            }
        }

        protected void WriteDailyCap(ApplicationInsightsComponentBillingFeatures billing)
        {
            if (billing != null)
            {
                WriteObject(new PSDailyCap(billing));
            }
        }

        protected void WriteComponent(ApplicationInsightsComponent component)
        {
            if (component != null)
            {
                WriteObject(PSApplicationInsightsComponent.Create(component));
            }
        }

        protected void WriteComponentList(IEnumerable<ApplicationInsightsComponent> components)
        {
            if (components != null)
            {
                List<PSApplicationInsightsComponent> output = new List<PSApplicationInsightsComponent>();
                components.ForEach(c => output.Add(PSApplicationInsightsComponent.Create(c)));
                WriteObject(output, true);
            }
        }

        protected void WriteComponentApiKeys(IEnumerable<ApplicationInsightsComponentAPIKey> apiKeys)
        {
            if (apiKeys != null && apiKeys.Any())
            {
                List<PSApiKey> output = new List<PSApiKey>();
                apiKeys.ForEach(e => output.Add(new PSApiKey(e)));
                WriteObject(output);
            }
        }

        protected void WriteComponentApiKey(ApplicationInsightsComponentAPIKey apiKey)
        {
            if (apiKey != null)
            {
                WriteObject(new PSApiKey(apiKey));
            }
        }

        protected void WriteComponentExportConfiguration(IEnumerable<ApplicationInsightsComponentExportConfiguration> exports)
        {
            if (exports != null && exports.Any())
            {
                List<PSExportConfiguration> output = new List<PSExportConfiguration>();
                exports.ForEach(e => output.Add(new PSExportConfiguration(e)));
                WriteObject(output);
            }
        }

        protected void WriteComponentExportConfiguration(ApplicationInsightsComponentExportConfiguration export)
        {
            if (export != null)
            {
                WriteObject(new PSExportConfiguration(export));
            }
        }

        protected void WriteDailyCapStatus(ApplicationInsightsComponentQuotaStatus quotaStatus)
        {
            if (quotaStatus != null)
            {
                WriteObject(new PSDailyCapStatus(quotaStatus));
            }
        }

        protected static string ParseSubscriptionFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[1];
            }

            return null;
        }

        protected static string[] ConvertToRecordType(string[] documentTypes)
        {
            if (documentTypes == null)
            {
                throw new ArgumentNullException("documentTypes");
            }

            Dictionary<string, string> mapping = new Dictionary<string, string>();
            mapping.Add(DocumentType.Requests.ToLowerInvariant(), RecordType.Requests);
            mapping.Add(DocumentType.Event.ToLowerInvariant(), RecordType.Event);
            mapping.Add(DocumentType.Exceptions.ToLowerInvariant(), RecordType.Exceptions);
            mapping.Add(DocumentType.Messages.ToLowerInvariant(), RecordType.Messages);
            mapping.Add(DocumentType.Metrics.ToLowerInvariant(), RecordType.Metrics);
            mapping.Add(DocumentType.PageViewPerformance.ToLowerInvariant(), RecordType.PageViewPerformance);
            mapping.Add(DocumentType.PageViews.ToLowerInvariant(), RecordType.PageViews);
            mapping.Add(DocumentType.RemoteDependency.ToLowerInvariant(), RecordType.RemoteDependency);
            mapping.Add(DocumentType.Availability.ToLowerInvariant(), RecordType.Availability);
            mapping.Add(DocumentType.PerformanceCounters.ToLowerInvariant(), RecordType.PerformanceCounters);

            return documentTypes.Select(d => mapping[d.Trim().ToLowerInvariant()]).ToArray();
        }

        internal static string[] ConvertToDocumentType(string[] recordTypes)
        {
            if (recordTypes == null)
            {
                throw new ArgumentNullException("documentTypes");
            }

            Dictionary<string, string> mapping = new Dictionary<string, string>();
            mapping.Add(RecordType.Requests.ToLowerInvariant(), DocumentType.Requests);
            mapping.Add(RecordType.Event.ToLowerInvariant(), DocumentType.Event);
            mapping.Add(RecordType.Exceptions.ToLowerInvariant(), DocumentType.Exceptions);
            mapping.Add(RecordType.Messages.ToLowerInvariant(), DocumentType.Messages);
            mapping.Add(RecordType.Metrics.ToLowerInvariant(), DocumentType.Metrics);
            mapping.Add(RecordType.PageViewPerformance.ToLowerInvariant(), DocumentType.PageViewPerformance);
            mapping.Add(RecordType.PageViews.ToLowerInvariant(), DocumentType.PageViews);
            mapping.Add(RecordType.RemoteDependency.ToLowerInvariant(), DocumentType.RemoteDependency);
            mapping.Add(RecordType.Availability.ToLowerInvariant(), DocumentType.Availability);
            mapping.Add(RecordType.PerformanceCounters.ToLowerInvariant(), DocumentType.PerformanceCounters);

            return recordTypes.Select(d => mapping[d.Trim().ToLowerInvariant()]).ToArray();
        }
    }
}
