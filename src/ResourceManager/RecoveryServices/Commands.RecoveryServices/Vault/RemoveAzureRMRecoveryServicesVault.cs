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
using System.Net;
using Microsoft.Azure.Commands.RecoveryServices.Properties;
using Microsoft.Azure.Management.RecoveryServices.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to initiate a vault delete operation.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmRecoveryServicesVault")]
    public class RemoveAzureRmRecoveryServicesVault : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets vault Object.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }

        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                RecoveryServicesOperationStatusResponse response = RecoveryServicesClient.DeleteVault(this.Vault.ResourceGroupName, this.Vault.Name);

                VaultOperationOutput output = new VaultOperationOutput()
                {
                    Response = response.StatusCode == HttpStatusCode.OK ? Resources.VaultDeletionSuccessMessage : response.StatusCode.ToString()
                };

                this.WriteObject(output, true);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
