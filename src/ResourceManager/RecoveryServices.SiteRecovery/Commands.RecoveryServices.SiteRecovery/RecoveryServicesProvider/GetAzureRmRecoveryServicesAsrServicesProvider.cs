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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Gets the details of the ASR recovery services providers registered to the Recovery Services vault.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrServicesProvider",
        DefaultParameterSetName = ASRParameterSets.Default)]
    [Alias("Get-ASRServicesProvider")]
    [OutputType(typeof(IEnumerable<ASRRecoveryServicesProvider>))]
    public class GetAzureRmRecoveryServicesAsrServicesProvider : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the name of the ASR recovery services provider to get details for.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the friendly name of the ASR recovery services provider to get details for.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets the ASR fabric object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            ValueFromPipeline = true,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            ValueFromPipeline = true,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByFriendlyName,
            ValueFromPipeline = true,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
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
        ///     Queries all / by default.
        /// </summary>
        private void GetAll()
        {
            var recoveryServicesProviderListResponse =
                this.RecoveryServicesClient.GetAzureSiteRecoveryProvider(this.Fabric.Name);

            foreach (var recoveryServicesProvider in recoveryServicesProviderListResponse)
            {
                this.WriteServicesProvider(recoveryServicesProvider);
            }
        }

        /// <summary>
        ///     Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            var found = false;

            var recoveryServicesProviderListResponse =
                this.RecoveryServicesClient.GetAzureSiteRecoveryProvider(this.Fabric.Name);

            foreach (var recoveryServicesProvider in recoveryServicesProviderListResponse)
            {
                if (0 ==
                    string.Compare(
                        this.FriendlyName,
                        recoveryServicesProvider.Properties.FriendlyName,
                        true))
                {
                    this.WriteServicesProvider(recoveryServicesProvider);
                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.ServicesProviderNotFound,
                        this.FriendlyName,
                        PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        ///     Queries by name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var recoveryServicesProviderResponse =
                    this.RecoveryServicesClient.GetAzureSiteRecoveryProvider(
                        this.Fabric.Name,
                        this.Name);

                if (recoveryServicesProviderResponse != null)
                {
                    this.WriteServicesProvider(recoveryServicesProviderResponse);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(
                        ex.Error.Code,
                        "NotFound",
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.ServicesProviderNotFound,
                            this.Name,
                            PSRecoveryServicesClient.asrVaultCreds.ResourceName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Write Powershell Recovery Services Provider.
        /// </summary>
        /// <param name="provider">Recovery Service Provider object</param>
        private void WriteServicesProvider(
            RecoveryServicesProvider provider)
        {
            this.WriteObject(new ASRRecoveryServicesProvider(provider));
        }
    }
}