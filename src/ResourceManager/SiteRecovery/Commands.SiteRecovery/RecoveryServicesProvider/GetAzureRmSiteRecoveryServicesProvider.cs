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
using Hyak.Common;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Services Provider.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryServicesProvider", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRRecoveryServicesProvider>))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Get-AzureRmRecoveryServicesAsrServicesProvider cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class GetAzureRmSiteRecoveryServicesProvider : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets ID of the Recovery Services Provider.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets name of the Recovery Services Provider.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets Fabric object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, ValueFromPipeline = true, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByName, ValueFromPipeline = true, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, ValueFromPipeline = true, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

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
            bool found = false;

            RecoveryServicesProviderListResponse recoveryServicesProviderListResponse =
                    RecoveryServicesClient.GetAzureSiteRecoveryProvider(
                    Fabric.Name);

            foreach (RecoveryServicesProvider recoveryServicesProvider in recoveryServicesProviderListResponse.RecoveryServicesProviders)
            {
                if (0 == string.Compare(this.FriendlyName, recoveryServicesProvider.Properties.FriendlyName, true))
                {
                    this.WriteServicesProvider(recoveryServicesProvider);
                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ServicesProviderNotFound,
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
                var recoveryServicesProviderResponse = RecoveryServicesClient.GetAzureSiteRecoveryProvider(
                        Fabric.Name,
                        this.Name);

                if (recoveryServicesProviderResponse.RecoveryServicesProvider != null)
                {
                    this.WriteServicesProvider(recoveryServicesProviderResponse.RecoveryServicesProvider);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code, "NotFound", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                        Properties.Resources.ServicesProviderNotFound,
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
            RecoveryServicesProviderListResponse recoveryServicesProviderListResponse =
                    RecoveryServicesClient.GetAzureSiteRecoveryProvider(
                    Fabric.Name);

            foreach (RecoveryServicesProvider recoveryServicesProvider in recoveryServicesProviderListResponse.RecoveryServicesProviders)
            {
                this.WriteServicesProvider(recoveryServicesProvider);
            }
        }

        /// <summary>
        /// Write Powershell Recovery Services Provider.
        /// </summary>
        /// <param name="provider">Recovery Service Provider object</param>
        private void WriteServicesProvider(RecoveryServicesProvider provider)
        {
            this.WriteObject(new ASRRecoveryServicesProvider(provider));
        }
    }
}