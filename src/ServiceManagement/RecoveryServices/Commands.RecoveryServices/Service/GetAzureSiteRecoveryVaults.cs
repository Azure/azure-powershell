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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.RecoveryServices.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Site Recovery Server.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryVaults")]
    [OutputType(typeof(List<ASRVault>))]
    public class GetAzureSiteRecoveryVaults : RecoveryServicesCmdletBase
    {
        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                IEnumerable<CloudService> cloudServiceList = RecoveryServicesClient.GetCloudServices();

                List<ASRVault> vaultList = new List<ASRVault>();
                foreach (var cloudService in cloudServiceList)
                {
                    foreach (var vault in cloudService.Resources)
                    {
                        if (vault.Type.Equals(Constants.ASRVaultType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            vaultList.Add(new ASRVault(cloudService, vault));
                        }
                    }
                }

                this.WriteVaults(vaultList);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Writes Virtual Machines.
        /// </summary>
        /// <param name="vaultList">List of Vaults</param>
        private void WriteVaults(IList<ASRVault> vaultList)
        {
            this.WriteObject(vaultList, true);
        }
    }
}
