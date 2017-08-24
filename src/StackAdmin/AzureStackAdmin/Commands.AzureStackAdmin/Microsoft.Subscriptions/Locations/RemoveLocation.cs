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
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure;
    using Microsoft.AzureStack.Management;

    /// <summary>
    /// Remove managed location cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, Nouns.Location, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureOperationResponse))]
    [Alias("Remove-AzureRmManagedLocation")]
    public class RemoveLocation : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        [ValidatePattern("^[0-9a-z]+$")]
        public string Name { get; set; }

        /// <summary>
        /// Removes the specified location
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Remove-AzureRmManagedLocation", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Remove-AzureRmManagedLocation will be deprecated in a future release. Please use the cmdlet name Remove-AzsLocation instead");
            }

            if (ShouldProcess(this.Name, VerbsCommon.Remove))
            {
                using (var client = this.GetAzureStackClient())
                {
                    this.WriteVerbose(Resources.RemovingLocation.FormatArgs(this.Name));
                    var result = client.ManagedLocations.Delete(this.Name);
                    WriteObject(result);
                }
            }
        }
    }
}
