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

namespace Microsoft.AzureStack.Commands
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.WindowsAzure;
    using Microsoft.AzureStack.Management;

    /// <summary>
    /// Remove Resource Provider Manifest Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, Nouns.ResourceProviderManifest, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureOperationResponse))]
    [Alias("Remove-AzureRmResourceProviderRegistration")]
    public class RemoveResourceProviderManifest : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the resource provider registration name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        [ValidateLength(1, 90)]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Remove-AzureRmResourceProviderRegistration", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Remove-AzureRmResourceProviderRegistration will be deprecated in a future release. Please use the cmdlet Remove-AzsResourceProviderManifest instead");
            }

            if (ShouldProcess(this.Name, VerbsCommon.Remove))
            {
                using (var client = this.GetAzureStackClient())
                {
                    this.WriteVerbose(Resources.RemovingResourceProviderRegistration.FormatArgs(this.Name));
                    var result = client.ProviderRegistrations.Delete(this.ResourceGroupName, this.Name);
                }
            }
        }
    }
}
