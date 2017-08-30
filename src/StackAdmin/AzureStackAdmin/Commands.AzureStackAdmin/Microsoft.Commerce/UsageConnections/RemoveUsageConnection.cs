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
    using Microsoft.AzureStack.Management;

    /// <summary>
    /// Remove Usage Connection Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, Nouns.UsageConnection, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureOperationResponse))]
    [Alias("Remove-AzureRmUsageConnection")]
    public class RemoveUsageConnection : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateLength(1, 90)]
        [ValidateNotNull]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Remove-AzureRmUsageConnection", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Remove-AzureRmUsageConnection will be deprecated in a future release. Please use the cmdlet name Remove-AzsUsageConection instead");
            }

            if (ShouldProcess(this.Name, VerbsCommon.Remove))
            {
                this.ApiVersion = UsageApiVersion;
                using (var client = this.GetAzureStackClient())
                {

                    this.WriteVerbose(Resources.RemovingUsageConnection.FormatArgs(this.Name));
                    var result = client.UsageConnections.Delete(this.ResourceGroupName, this.Name);
                    WriteObject(result);
                }
            }
        }
    }
}
