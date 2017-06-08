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
using Hyak.Common;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    /// Gets Azure Site Recovery fabric object.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesAsrFabric", DefaultParameterSetName = ASRParameterSets.Default)]
    [Alias("Get-ASRFabric")]
    [OutputType(typeof(List<ASRFabric>))]
    public class GetAzureRmRecoveryServicesAsrFabric : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Name of the Fabric.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Friendly name of the Fabric.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByName:
                    this.GetByName();
                    break;
                case ASRParameterSets.ByFriendlyName:
                    this.GetByFriendlyName();
                    break;
                case ASRParameterSets.Default:
                    this.GetAll();
                    break;
            }
        }

        /// <summary>
        /// Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            List<Fabric> fabricListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryFabric();

            bool found = false;
            foreach (Fabric fabric in fabricListResponse)
            {
                if (0 == string.Compare(this.FriendlyName, fabric.Properties.FriendlyName, StringComparison.OrdinalIgnoreCase))
                {
                    var fabricByName = RecoveryServicesClient.GetAzureSiteRecoveryFabric(fabric.Name);
                    this.WriteFabric(fabricByName);

                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.FabricNotFound,
                    this.FriendlyName,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        /// Queries by name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var fabricResponse =
                    RecoveryServicesClient.GetAzureSiteRecoveryFabric(this.Name);

                if (fabricResponse != null)
                {
                    this.WriteFabric(fabricResponse);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code, "NotFound", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Properties.Resources.FabricNotFound,
                            this.Name,
                            PSRecoveryServicesClient.asrVaultCreds.ResourceName));
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Queries all / by default.
        /// </summary>
        private void GetAll()
        {
            List<Fabric> fabricListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryFabric();

            foreach (Fabric fabric in fabricListResponse)
            {
                this.WriteFabric(fabric);
            }
        }

        /// <summary>
        /// Write Powershell Fabric.
        /// </summary>
        /// <param name="server">Fabric object</param>
        private void WriteFabric(Fabric fabric)
        {
            this.WriteObject(new ASRFabric(fabric));
        }
    }
}
