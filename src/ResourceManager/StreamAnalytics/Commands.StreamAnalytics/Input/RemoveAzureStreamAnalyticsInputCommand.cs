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

using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Security.Permissions;
using Microsoft.Azure.Commands.StreamAnalytics.Properties;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    [Cmdlet(VerbsCommon.Remove, Constants.StreamAnalyticsInput)]
    public class RemoveAzureStreamAnalyticsInputCommand : StreamAnalyticsResourceProviderBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The azure stream analytics job name.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The stream analytics input name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        protected override void ProcessRecord()
        {
            if (ResourceGroupName != null && string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                throw new PSArgumentNullException("ResourceGroupName");
            }

            if (JobName != null && string.IsNullOrWhiteSpace(JobName))
            {
                throw new PSArgumentNullException("JobName");
            }

            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new PSArgumentNullException("Name");
            }

            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.InputRemovalConfirmationMessage,
                    this.Name,
                    this.JobName,
                    this.ResourceGroupName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.InputRemoving,
                    this.Name,
                    this.JobName,
                    this.ResourceGroupName),
                this.Name,
                this.ExecuteDelete);
        }

        private void ExecuteDelete()
        {
            HttpStatusCode statusCode = StreamAnalyticsClient.RemovePSInput(ResourceGroupName, JobName, Name);
            if (statusCode == HttpStatusCode.NoContent)
            {
                WriteWarning(string.Format(CultureInfo.InvariantCulture, Resources.InputNotFound, Name, JobName, ResourceGroupName));
            }
            else
            {
                WriteObject(true);
            }
        }
    }
}