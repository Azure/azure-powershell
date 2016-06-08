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

using Hyak.Common;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.StreamAnalytics.Models;
using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using System;
using System.Globalization;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    public abstract class StreamAnalyticsBaseCmdlet : AzureRMCmdlet
    {
        private StreamAnalyticsClient streamAnalyticsClient;

        protected const string StreamAnalyticsObjectsInSubscription = "For stream analytics objects in the given subscription";
        protected const string StreamAnalyticsObjectsInResourceGroup = "For stream analytics objects in the given resource group";

        internal StreamAnalyticsClient StreamAnalyticsClient
        {
            get
            {
                if (this.streamAnalyticsClient == null)
                {
                    this.streamAnalyticsClient = new StreamAnalyticsClient(DefaultProfile.Context);
                }
                return this.streamAnalyticsClient;
            }
            set
            {
                this.streamAnalyticsClient = value;
            }
        }

        protected override void WriteExceptionError(Exception exception)
        {
            // Override the default error message into a formatted message which contains Request Id
            CloudException cloudException = exception as CloudException;
            if (cloudException != null)
            {
                exception = cloudException.CreateFormattedException();
            }

            base.WriteExceptionError(exception);
        }

        protected string ResolveResourceName(string rawJsonContent, string nameFromCmdletContext, string resourceType)
        {
            string nameExtractedFromJson = StreamAnalyticsCommonUtilities.ExtractNameFromJson(rawJsonContent);

            // Read the name from the JSON content if user didn't provide name with -Name parameter
            string resolvedResourceName = string.IsNullOrWhiteSpace(nameFromCmdletContext)
                ? nameExtractedFromJson
                : nameFromCmdletContext;

            // Show a message that if name from json is not null or empty and names do not match, name specified with -Name parameter will be used.
            if (!string.IsNullOrEmpty(nameExtractedFromJson) && string.Compare(resolvedResourceName, nameExtractedFromJson, StringComparison.OrdinalIgnoreCase) != 0)
            {
                WriteVerbose(string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.ExtractedNameFromJsonMismatchWarning,
                    resourceType,
                    resolvedResourceName,
                    nameExtractedFromJson));
            }

            return resolvedResourceName;
        }
    }
}
