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

using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.CloudService
{
    [Cmdlet(VerbsCommon.Remove, "WAPackCloudService", DefaultParameterSetName = WAPackCmdletParameterSets.FromCloudServiceObject, SupportsShouldProcess = true)]
    public class RemoveWAPackCloudService : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromCloudServiceObject, ValueFromPipeline = true, HelpMessage = "Existing CloudService Object.")]
        [ValidateNotNullOrEmpty]
        public Utilities.WAPackIaaS.DataContract.CloudService CloudService
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Position = 2, HelpMessage = "Confirm the removal of the CloudService.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
            Force.IsPresent,
            string.Format(Resources.RemoveCloudServiceConfirmationMessage, CloudService.Name),
            string.Format(Resources.RemoveCloudServiceMessage),
            CloudService.Name,
            () =>
            {
                Guid? cloudServiceJobId = null;
                var cloudServiceOperations = new CloudServiceOperations(this.WebClientFactory);

                var deletedCloudService = cloudServiceOperations.Read(CloudService.Name);
                cloudServiceOperations.Delete(CloudService.Name, out cloudServiceJobId);
                var jobInfo = WaitForJobCompletion(cloudServiceJobId);

                if (this.PassThru)
                {
                    WriteObject(jobInfo.jobStatus != JobStatusEnum.Failed);
                }
            });
        }
    }
}
