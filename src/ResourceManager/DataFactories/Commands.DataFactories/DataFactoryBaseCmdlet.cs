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
using Microsoft.Azure.Commands.DataFactories.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataFactories
{
    public abstract class DataFactoryBaseCmdlet : AzureRMCmdlet
    {
        private DataFactoryClient dataFactoryClient;

        protected const string ByFactoryObject = "ByFactoryObject";
        protected const string ByFactoryName = "ByFactoryName";

        [Parameter(ParameterSetName = ByFactoryName, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        internal DataFactoryClient DataFactoryClient
        {
            get
            {
                if (this.dataFactoryClient == null)
                {
                    this.dataFactoryClient = new DataFactoryClient(DefaultContext);
                }
                return this.dataFactoryClient;
            }
            set
            {
                this.dataFactoryClient = value;
            }
        }

        protected override void WriteExceptionError(Exception exception)
        {
            if (exception is CloudException)
            {
                // Override the default error message into a formatted message which contains Request Id
                exception = ((CloudException)exception).CreateFormattedException();
            }
            else if (exception is ArgumentOutOfRangeException)
            {
                // Add resource naming rules page link into a formatted message
                exception = ((ArgumentOutOfRangeException)exception).CreateFormattedException();
            }

            base.WriteExceptionError(exception);
        }

        protected string ResolveResourceName(string rawJsonContent, string nameFromCmdletContext, string resourceType)
        {
            string nameExtractedFromJson = DataFactoryCommonUtilities.ExtractNameFromJson(rawJsonContent, resourceType);

            // Read the name from the JSON content if user didn't provide name with -Name parameter
            string resolvedResourceName = string.IsNullOrWhiteSpace(nameFromCmdletContext)
                ? nameExtractedFromJson
                : nameFromCmdletContext;

            // Show a message that if names do not match, name specified with -Name parameter will be used.
            if (string.Compare(resolvedResourceName, nameExtractedFromJson, StringComparison.OrdinalIgnoreCase) != 0)
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
