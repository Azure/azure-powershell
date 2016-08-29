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

using Microsoft.Azure.Management.SiteRecovery.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Server.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryServer", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRServer>))]
    public class GetAzureSiteRecoveryServer : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets ID of the Server.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets name of the Server.
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
                // Do not process for fabrictype other than Vmm|HyperVSite 
                if (String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.VMM) != 0 && String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.HyperVSite) != 0)
                    continue;

                RecoveryServicesProviderListResponse recoveryServicesProviderListResponse =
                        RecoveryServicesClient.GetAzureSiteRecoveryProvider(
                        fabric.Name);

                foreach (RecoveryServicesProvider recoveryServicesProvider in recoveryServicesProviderListResponse.RecoveryServicesProviders)
                {
                    if (0 == string.Compare(this.FriendlyName, recoveryServicesProvider.Properties.FriendlyName, true))
                    {
                        this.WriteServer(fabric, recoveryServicesProvider);
                        found = true;
                    }
                }

            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ServerNotFound,
                    this.FriendlyName,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        /// Queries by name.
        /// </summary>
        private void GetByName()
        {
            FabricListResponse fabricListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryFabric();

            bool found = false;
            foreach (Fabric fabric in fabricListResponse.Fabrics)
            {
                // Do not process for fabrictype other than Vmm|HyperVSite 
                if (String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.VMM) != 0 && String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.HyperVSite) != 0)
                    continue;

                RecoveryServicesProviderListResponse recoveryServicesProviderListResponse =
                        RecoveryServicesClient.GetAzureSiteRecoveryProvider(
                        fabric.Name);

                foreach (RecoveryServicesProvider recoveryServicesProvider in recoveryServicesProviderListResponse.RecoveryServicesProviders)
                {
                    if (0 == string.Compare(this.Name, recoveryServicesProvider.Name, true))
                    {
                        this.WriteServer(fabric, recoveryServicesProvider);
                        found = true;
                    }
                }

            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ServerNotFound,
                    this.Name,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
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
                // Do not process for fabrictype other than Vmm|HyperVSite 
                if (String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.VMM) != 0 && String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.HyperVSite) != 0)
                    continue;

                RecoveryServicesProviderListResponse recoveryServicesProviderListResponse =
                        RecoveryServicesClient.GetAzureSiteRecoveryProvider(
                        fabric.Name);

                foreach (RecoveryServicesProvider recoveryServicesProvider in recoveryServicesProviderListResponse.RecoveryServicesProviders)
                {
                    this.WriteServer(fabric, recoveryServicesProvider);
                }
            }
        }

        /// <summary>
        /// Write Powershell Server.
        /// </summary>
        /// <param name="server">Fabric object</param>
        /// <param name="provider">Recovery Service Provider object</param>
        private void WriteServer(Fabric fabric, RecoveryServicesProvider provider)
        {
            this.WriteObject(new ASRServer(fabric, provider));
        }
    }
}