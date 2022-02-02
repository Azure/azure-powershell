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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Bicep
{
    [Cmdlet(VerbsData.Publish, AzureRMConstants.AzureRMPrefix + "BicepModule", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class PublishAzureBicepModuleCmdlet : AzureRMCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the bicep file to publish.")]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target location where the bicep file will be published.")]
        [ValidateNotNullOrEmpty]
        public string Target { get; set; }

        [Parameter(Mandatory = false, HelpMessage="Indicates that this cmdlet returns a boolean result. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            BicepUtility.PublishFile(this.TryResolvePath(this.FilePath), this.Target, this.WriteVerbose, this.WriteWarning);

            if (this.PassThru.IsPresent)
            {
                this.WriteObject(true);
            }
        }
    }
}
