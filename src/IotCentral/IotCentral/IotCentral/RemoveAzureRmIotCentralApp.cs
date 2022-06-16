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

using Microsoft.Azure.Commands.IotCentral.Common;
using Azure.ResourceManager.IotCentral;

using System.Management.Automation;
using ResourceProperties = Microsoft.Azure.Commands.Management.IotCentral.Properties;
using Azure.Core;
using Azure;
using System.Threading;

namespace Microsoft.Azure.Commands.Management.IotCentral
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotCentralApp", SupportsShouldProcess = true, DefaultParameterSetName = ResourceIdParameterSet)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmIotCentralApp : IotCentralFullParameterSetCmdlet
    {
        [Parameter(
            Mandatory = false, 
            HelpMessage = "Set to receive boolean success output from Cmdlet.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            this.SetNameAndResourceGroup();
            if (ShouldProcess(Name, ResourceProperties.Resources.RemoveIotCentralApp))
            {
                var iotCentralAppResource = this.IotCentralClient.GetIotCentralAppResource(new ResourceIdentifier($"/subscriptions/{DefaultContext.Subscription.Id}/resourceGroups/{ResourceGroupName}/providers/Microsoft.IoTCentral/{resourceType}/{Name}"));
                iotCentralAppResource.Delete(WaitUntil.Completed, CancellationToken.None);
                if (PassThru)
                {
                    this.WriteObject(true);
                }
            }
        }
    }
}
