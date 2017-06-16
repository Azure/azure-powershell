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
    ///     Retrieves Azure Site Recovery Services Provider.
    /// </summary>
    [Cmdlet(VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrServicesProvider",
        DefaultParameterSetName = ASRParameterSets.Default)]
    [Alias("Get-ASRServicesProvider")]
    [OutputType(typeof(IEnumerable<ASRRecoveryServicesProvider>))]
    public class GetAzureRmRecoveryServicesAsrServicesProvider : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets ID of the Recovery Services Provider.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets name of the Recovery Services Provider.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Fabric object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default,
            ValueFromPipeline = true,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByName,
            ValueFromPipeline = true,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName,
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

            switch (ParameterSetName)
            {
                case ASRParameterSets.ByName:
                    GetByName();
                    break;
                case ASRParameterSets.ByFriendlyName:
                    GetByFriendlyName();
                    break;
                case ASRParameterSets.Default:
                    GetAll();
                    break;
            }
        }

        /// <summary>
        ///     Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            var found = false;

            var recoveryServicesProviderListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProvider(Fabric.Name);

            foreach (var recoveryServicesProvider in recoveryServicesProviderListResponse)
            {
                if (0 ==
                    string.Compare(FriendlyName,
                        recoveryServicesProvider.Properties.FriendlyName,
                        true))
                {
                    WriteServicesProvider(recoveryServicesProvider);
                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(string.Format(
                    Resources.ServicesProviderNotFound,
                    FriendlyName,
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
                    RecoveryServicesClient.GetAzureSiteRecoveryProvider(Fabric.Name,
                        Name);

                if (recoveryServicesProviderResponse != null)
                {
                    WriteServicesProvider(recoveryServicesProviderResponse);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code,
                        "NotFound",
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(string.Format(
                        Resources.ServicesProviderNotFound,
                        Name,
                        PSRecoveryServicesClient.asrVaultCreds.ResourceName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Queries all / by default.
        /// </summary>
        private void GetAll()
        {
            var recoveryServicesProviderListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProvider(Fabric.Name);

            foreach (var recoveryServicesProvider in recoveryServicesProviderListResponse)
            {
                WriteServicesProvider(recoveryServicesProvider);
            }
        }

        /// <summary>
        ///     Write Powershell Recovery Services Provider.
        /// </summary>
        /// <param name="provider">Recovery Service Provider object</param>
        private void WriteServicesProvider(RecoveryServicesProvider provider)
        {
            WriteObject(new ASRRecoveryServicesProvider(provider));
        }
    }
}