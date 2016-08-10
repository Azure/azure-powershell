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
    [Cmdlet(VerbsCommon.New, Constants.StreamAnalyticsOutput, SupportsShouldProcess = true), 
        OutputType(typeof(PSOutput))]
    public class NewAzureStreamAnalyticsOutputCommand : StreamAnalyticsResourceProviderBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The stream analytics job name.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The stream analytics output name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The stream analytics output JSON file path.")]
        [ValidateNotNullOrEmpty]
        public string File { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            string rawJsonContent = StreamAnalyticsClient.ReadJsonFileContent(this.TryResolvePath(File));

            Name = ResolveResourceName(rawJsonContent, Name, "Output");

            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException(Resources.OutputNameCannotBeEmpty);
            }

            CreatePSOutputParameter parameter = new CreatePSOutputParameter
            {
                ResourceGroupName = ResourceGroupName,
                JobName = JobName,
                OutputName = Name,
                RawJsonContent = rawJsonContent,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction
            };

            var result = StreamAnalyticsClient.CreatePSOutput(parameter);
            if (result != null)
            {
                WriteObject(result);
            }
        }
    }
}