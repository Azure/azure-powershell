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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Creates Azure Site Recovery VM NIC IP configuration for A2A replication.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrVMNicIPConfig", DefaultParameterSetName = ASRParameterSets.AzureToAzure, SupportsShouldProcess = true)]
    [Alias("New-ASRVMNicIPConfig")]
    [OutputType(typeof(PSIPConfigInputDetails))]
    public class NewAzureRmAsrVmNicIPConfig : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        ///    Gets or sets the IP config name.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            HelpMessage = "Specify the IP config name.")]
        public string IpConfigName { get; set; }

        /// <summary>
        ///     Gets or sets whether an existing IP config is selected for test failover/failover.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies whether an existing IP config is selected for test failover/failover.")]
        public SwitchParameter IsSelectedForFailover { get; set; }

        /// <summary>
        ///     Gets or sets the name of the recovery subnet.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the name of the recovery subnet.")]
        [ValidateNotNullOrEmpty]
        public string RecoverySubnetName { get; set; }

        /// <summary>
        ///     Gets or sets the static IP address that should be assigned to IP config on recovery.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the IP address of the recovery IP config.")]
        [ValidateNotNull]
        public string RecoveryStaticIPAddress { get; set; }

        /// <summary>
        ///     Gets or sets the id of the public IP address resource associated with the recovery IP config.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the ID of the public IP address associated with the recovery IP config.")]
        [ValidateNotNull]
        public string RecoveryPublicIPAddressId { get; set; }

        /// <summary>
        ///     Gets or sets the target backend address pools for the recovery IP config.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the IDs of backend address pools for the recovery IP config.")]
        [ValidateNotNull]
        public string[] RecoveryLBBackendAddressPoolId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the test failover subnet.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the name of the test failover subnet.")]
        [ValidateNotNullOrEmpty]
        public string TfoSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets the static IP address that should be assigned to test failover IP config on recovery.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the IP address of the test failover IP config.")]
        [ValidateNotNull]
        public string TfoStaticIPAddress { get; set; }

        /// <summary>
        ///     Gets or sets the id of the public IP address resource associated with the test failover IP config.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the ID of the public IP address associated with the test failover IP config.")]
        [ValidateNotNull]
        public string TfoPublicIPAddressId { get; set; }

        /// <summary>
        ///     Gets or sets the target backend address pools for the test failover IP config.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the IDs of backend address pools for the test failover IP config.")]
        [ValidateNotNull]
        public string[] TfoLBBackendAddressPoolId { get; set; }

        #endregion Parameters

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            PSIPConfigInputDetails ipConfig = null;

            if (string.IsNullOrEmpty(this.RecoverySubnetName) &&
                !string.IsNullOrEmpty(this.RecoveryStaticIPAddress))
            {
                this.WriteWarning(Resources.RecoverySubnetInformationMissing);
                return;
            }

            if (string.IsNullOrEmpty(this.TfoSubnetName) &&
                !string.IsNullOrEmpty(this.TfoStaticIPAddress))
            {
                this.WriteWarning(Resources.TfoSubnetInformationMissing);
                return;
            }

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.AzureToAzure:

                    ipConfig = new PSIPConfigInputDetails
                    {
                        IPConfigName = this.IpConfigName,
                        IsSeletedForFailover = this.IsSelectedForFailover,
                        RecoverySubnetName = this.RecoverySubnetName,
                        RecoveryStaticIPAddress = this.RecoveryStaticIPAddress,
                        RecoveryPublicIPAddressId = this.RecoveryPublicIPAddressId,
                        RecoveryLBBackendAddressPoolIds = this.RecoveryLBBackendAddressPoolId?.ToList(),
                        TfoSubnetName = this.TfoSubnetName,
                        TfoStaticIPAddress = this.TfoStaticIPAddress,
                        TfoPublicIPAddressId = this.TfoPublicIPAddressId,
                        TfoLBBackendAddressPoolIds = this.TfoLBBackendAddressPoolId?.ToList()
                    };

                    break;
            }

            this.WriteObject(ipConfig);
        }
    }
}
