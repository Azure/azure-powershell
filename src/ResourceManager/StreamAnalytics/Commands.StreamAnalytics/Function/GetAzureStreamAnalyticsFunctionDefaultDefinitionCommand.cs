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

using Microsoft.Azure.Commands.StreamAnalytics.Models;
using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    [Cmdlet(VerbsCommon.Get, Constants.StreamAnalyticsDefaultFunctionDefinition), OutputType(typeof(PSFunction))]
    public class GetAzureStreamAnalyticsFunctionDefaultDefinitionCommand : StreamAnalyticsResourceProviderBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The stream analytics job name.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The stream analytics function name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The stream analytics function JSON file path.")]
        [ValidateNotNullOrEmpty]
        public string File { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName != null && string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                throw new PSArgumentNullException("ResourceGroupName");
            }

            if (JobName != null && string.IsNullOrWhiteSpace(JobName))
            {
                throw new PSArgumentNullException("JobName");
            }

            if (File != null && string.IsNullOrWhiteSpace(File))
            {
                throw new PSArgumentNullException("File");
            }

            string rawJsonContent = StreamAnalyticsClient.ReadJsonFileContent(this.TryResolvePath(File));

            Name = ResolveResourceName(rawJsonContent, Name, "Function");

            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException(Resources.FunctionNameCannotBeEmpty);
            }

            RetrieveDefaultPSFunctionDefinitionParameter parameter = new RetrieveDefaultPSFunctionDefinitionParameter
            {
                ResourceGroupName = ResourceGroupName,
                JobName = JobName,
                FunctionName = Name,
                RawJsonContent = rawJsonContent
            };

            WriteObject(StreamAnalyticsClient.RetrieveDefaultPSFunctionDefinition(parameter));
        }
    }
}
