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
using System.ComponentModel;
using System.Management.Automation;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;
using System.Collections.Generic;
using Hyak.Common;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Gets Azure Site Recovery fabric object.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryFabric", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(List<ASRFabric>))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Get-AzureRmRecoveryServicesAsrFabric cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class GetAzureRmSiteRecoveryFabric : SiteRecoveryCmdletBase
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
            FabricListResponse fabricListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryFabric();

            bool found = false;
            foreach (Fabric fabric in fabricListResponse.Fabrics)
            {
                if (0 == string.Compare(this.FriendlyName, fabric.Properties.FriendlyName, StringComparison.OrdinalIgnoreCase))
                {
                    var fabricByName = RecoveryServicesClient.GetAzureSiteRecoveryFabric(fabric.Name).Fabric;
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

                if (fabricResponse.Fabric != null)
                {
                    this.WriteFabric(fabricResponse.Fabric);
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
            FabricListResponse fabricListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryFabric();

            foreach (Fabric fabric in fabricListResponse.Fabrics)
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
