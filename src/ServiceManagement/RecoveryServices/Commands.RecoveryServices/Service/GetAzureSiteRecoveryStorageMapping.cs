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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Site Recovery Storage mappings.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryStorageMapping")]
    [OutputType(typeof(IEnumerable<ASRStorageMapping>))]
    public class GetAzureSiteRecoveryStorageMapping : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Primary Server object.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRServer PrimaryServer { get; set; }

        /// <summary>
        /// Gets or sets Recovery Server object.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRServer RecoveryServer { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

                StorageMappingListResponse storageMappingListResponse =
                    RecoveryServicesClient
                    .GetAzureSiteRecoveryStorageMappings(this.PrimaryServer.ID, this.RecoveryServer.ID);

                this.WriteStorageMappings(storageMappingListResponse.StorageMappings);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Write Storage mappings.
        /// </summary>
        /// <param name="storageMappings">List of Storage mappings</param>
        private void WriteStorageMappings(IList<StorageMapping> storageMappings)
        {
            this.WriteObject(storageMappings.Select(sm => new ASRStorageMapping(sm)), true);
        }
    }
}