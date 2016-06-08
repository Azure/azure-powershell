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
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.CloudService
{
    /// <summary>
    /// Deletes the specified hosted service from Microsoft Azure.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureService", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureServiceCommand : AzureSMCmdlet
    {
        public ICloudServiceClient CloudServiceClient { get; set; }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "name of the hosted service")]
        public string ServiceName { get; set; }

        [Parameter(Position = 1, HelpMessage = "Do not confirm deletion of deployment")]
        public SwitchParameter Force { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "Specify to remove the service and the underlying disk blob(s).")]
        public SwitchParameter DeleteAll { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveServiceWarning),
                Resources.RemoveServiceWhatIfMessage,
                string.Empty,
                () =>
                {
                    CloudServiceClient = CloudServiceClient ?? new CloudServiceClient(
                        Profile,
                        Profile.Context.Subscription,
                        SessionState.Path.CurrentLocation.Path,
                        WriteDebug,
                        WriteVerbose,
                        WriteWarning);

                    CloudServiceClient.RemoveCloudService(ServiceName, DeleteAll.IsPresent);

                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}