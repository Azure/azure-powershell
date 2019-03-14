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
using Microsoft.Azure.Management.IotCentral;
using System.Management.Automation;
using ResourceProperties = Microsoft.Azure.Commands.Management.IotCentral.Properties;

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
                this.IotCentralClient.Apps.Delete(this.ResourceGroupName, this.Name);
                if (PassThru)
                {
                    this.WriteObject(true);
                }
            }
        }
    }
}
