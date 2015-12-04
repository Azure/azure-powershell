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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.CloudService
{
    /// <summary>
    /// Starts the deployment of specified slot in the azure service
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureService"), OutputType(typeof(bool))]
    public class StartAzureServiceCommand : AzureSMCmdlet
    {
        public ICloudServiceClient CloudServiceClient { get; set; }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        public string ServiceName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment slot. Staging | Production")]
        public string Slot { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            CloudServiceClient = CloudServiceClient ?? new CloudServiceClient(
                Profile,
                Profile.Context.Subscription,
                SessionState.Path.CurrentLocation.Path,
                WriteDebug,
                WriteVerbose,
                WriteWarning);

            CloudServiceClient.StartCloudService(ServiceName, Slot);

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}