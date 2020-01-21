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
    ///     Creates Azure Site Recovery VM NIC configuration for A2A replication.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrVMNicConfig", DefaultParameterSetName = ASRParameterSets.AzureToAzure, SupportsShouldProcess = true)]
    [Alias("New-ASRVMNicConfig")]
    [OutputType(typeof(ASRVMNicConfig))]
    public class NewAzureRmAsrVmNicConfig : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        ///    Gets or sets the NIC Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            HelpMessage = "Specify the ASR NIC GUID.")]
        public string NicId { get; set; }

        /// <summary>
        ///    Gets or sets the NIC Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            HelpMessage = "Specify the ASR Replication Protected Item.")]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets Id of the recovery VM Network.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the ID of the recovery virtual network.")]
        [ValidateNotNullOrEmpty]
        public string RecoveryVMNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the recovery VM subnet.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the name of the recovery subnet.")]
        [ValidateNotNullOrEmpty]
        public string RecoveryVMSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets the id of the NSG associated with the NIC.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the ID of the NSG associated with recovery NIC.")]
        [ValidateNotNullOrEmpty]
        public string RecoveryNetworkSecurityGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the availability set for replication protected item after failover.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies whether accelerated networking is enabled on recovery NIC.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableAcceleratedNetworkingOnRecovery { get; set; }

        /// <summary>
        ///     Gets or sets the static IP address that should be assigned to primary NIC on recovery.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the IP address of the recovery NIC.")]
        [ValidateNotNull]
        public string RecoveryNicStaticIPAddress { get; set; }

        /// <summary>
        ///     Gets or sets the id of the public IP address resource associated with the NIC.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the ID of the public IP address associated with recovery NIC.")]
        [ValidateNotNullOrEmpty]
        public string RecoveryPublicIPAddressId { get; set; }

        /// <summary>
        ///     Gets or sets the target backend address pools for the NIC.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the IDs of backend address pools for the recovery NIC.")]
        [ValidateNotNull]
        public string[] RecoveryLBBackendAddressPoolId { get; set; }

        /// <summary>
        ///     Gets or sets Id of the test failover VM Network.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the ID of the test failover virtual network.")]
        [ValidateNotNullOrEmpty]
        public string TfoVMNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the test failover subnet.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the name of the test failover subnet.")]
        [ValidateNotNullOrEmpty]
        public string TfoVMSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets the id of the NSG associated with the test failover NIC.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the ID of the NSG associated with test failover NIC.")]
        [ValidateNotNullOrEmpty]
        public string TfoNetworkSecurityGroupId { get; set; }

        /// <summary>
        ///     Gets or sets whether the test failover NIC has accelerated networking enabled.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies whether accelerated networking is enabled on test failover NIC.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableAcceleratedNetworkingOnTfo { get; set; }

        /// <summary>
        ///     Gets or sets the static IP address that should be assigned to test failover NIC.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the IP address of the test failover NIC.")]
        [ValidateNotNull]
        public string TfoNicStaticIPAddress { get; set; }

        /// <summary>
        ///     Gets or sets the id of the public IP address resource associated with the test failover NIC.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the ID of the public IP address associated with test failover NIC.")]
        [ValidateNotNullOrEmpty]
        public string TfoPublicIPAddressId { get; set; }

        /// <summary>
        ///     Gets or sets the target backend address pools for the NIC.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the IDs of backend address pools for the recovery NIC.")]
        [ValidateNotNull]
        public string[] TfoLBBackendAddressPoolId { get; set; }

        #endregion Parameters

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            ASRVMNicConfig nicConfig = null;

            if (string.IsNullOrEmpty(this.RecoveryVMNetworkId) &&
                !string.IsNullOrEmpty(this.RecoveryVMSubnetName))
            {
                this.WriteWarning(Resources.RecoveryNetworkInformationMissing);
                return;
            }

            if (string.IsNullOrEmpty(this.TfoVMNetworkId) &&
                !string.IsNullOrEmpty(this.TfoVMSubnetName))
            {
                this.WriteWarning(Resources.TfoNetworkInformationMissing);
                return;
            }

            if (string.IsNullOrEmpty(this.RecoveryVMSubnetName) &&
                !string.IsNullOrEmpty(this.RecoveryNicStaticIPAddress))
            {
                this.WriteWarning(Resources.RecoverySubnetInformationMissing);
                return;
            }

            if (string.IsNullOrEmpty(this.TfoVMSubnetName) &&
                !string.IsNullOrEmpty(this.TfoNicStaticIPAddress))
            {
                this.WriteWarning(Resources.TfoSubnetInformationMissing);
                return;
            }

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.AzureToAzure:

                    var providerSpecificDetails =
                        this.ReplicationProtectedItem.ProviderSpecificDetails;

                    if (!(providerSpecificDetails is ASRAzureToAzureSpecificRPIDetails))
                    {
                        this.WriteWarning(
                            Resources.UnsupportedReplicationProvidedForASRVMNicConfig);
                        return;
                    }

                    var vmNicDetailsList =
                        this.ReplicationProtectedItem.NicDetailsList ??
                        new List<ASRVMNicDetails>();

                    var vmNic =
                        vmNicDetailsList.FirstOrDefault(
                            nic => nic.NicId.Equals(
                                this.NicId, StringComparison.OrdinalIgnoreCase));

                    if (vmNic == null)
                    {
                        this.WriteWarning(string.Format(Resources.NicNotFoundInVM, this.NicId));
                        return;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryVMNetworkId)))
                    {
                        this.RecoveryVMNetworkId =
                            this.ReplicationProtectedItem.SelectedRecoveryAzureNetworkId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryVMSubnetName)))
                    {
                        this.RecoveryVMSubnetName = vmNic.RecoveryVMSubnetName;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryNicStaticIPAddress)))
                    {
                        this.RecoveryNicStaticIPAddress = vmNic.ReplicaNicStaticIPAddress;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryNetworkSecurityGroupId)))
                    {
                        this.RecoveryNetworkSecurityGroupId = vmNic.RecoveryNetworkSecurityGroupId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() =>
                            this.EnableAcceleratedNetworkingOnRecovery)))
                    {
                        this.EnableAcceleratedNetworkingOnRecovery =
                            vmNic.EnableAcceleratedNetworkingOnRecovery ?? false;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryPublicIPAddressId)))
                    {
                        this.RecoveryPublicIPAddressId = vmNic.RecoveryPublicIPAddressId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryLBBackendAddressPoolId)))
                    {
                        this.RecoveryLBBackendAddressPoolId =
                            vmNic.RecoveryLBBackendAddressPoolId?.ToArray();
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.TfoVMNetworkId)))
                    {
                        this.TfoVMNetworkId =
                            this.ReplicationProtectedItem.SelectedTfoAzureNetworkId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.TfoVMSubnetName)))
                    {
                        this.TfoVMSubnetName = vmNic.TfoVMSubnetName;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.TfoNicStaticIPAddress)))
                    {
                        this.TfoNicStaticIPAddress =
                            vmNic.TfoIPConfigs?.FirstOrDefault()?.StaticIPAddress ?? string.Empty;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.TfoNetworkSecurityGroupId)))
                    {
                        this.TfoNetworkSecurityGroupId = vmNic.TfoNetworkSecurityGroupId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() =>
                            this.EnableAcceleratedNetworkingOnTfo)))
                    {
                        this.EnableAcceleratedNetworkingOnTfo =
                            vmNic.EnableAcceleratedNetworkingOnTfo ?? false;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.TfoPublicIPAddressId)))
                    {
                        this.TfoPublicIPAddressId =
                            vmNic.TfoIPConfigs?.FirstOrDefault()?.PublicIpAddressId ?? string.Empty;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.TfoLBBackendAddressPoolId)))
                    {
                        this.TfoLBBackendAddressPoolId =
                            vmNic.TfoIPConfigs?.FirstOrDefault()?.LBBackendAddressPoolIds?.ToArray();
                    }

                    nicConfig = new ASRVMNicConfig
                    {
                        NicId = this.NicId,
                        RecoveryVMNetworkId = this.RecoveryVMNetworkId,
                        RecoveryVMSubnetName = this.RecoveryVMSubnetName,
                        RecoveryNetworkSecurityGroupId = this.RecoveryNetworkSecurityGroupId,
                        EnableAcceleratedNetworkingOnRecovery =
                            this.EnableAcceleratedNetworkingOnRecovery,
                        RecoveryIPConfigs =
                            new List<IPConfig>
                            {
                                new IPConfig
                                {
                                    StaticIPAddress = this.RecoveryNicStaticIPAddress,
                                    PublicIpAddressId = this.RecoveryPublicIPAddressId,
                                    LBBackendAddressPoolIds =
                                        this.RecoveryLBBackendAddressPoolId?.ToList() ??
                                        new List<string>()
                                }
                            },

                        TfoVMNetworkId = this.TfoVMNetworkId,
                        TfoVMSubnetName = this.TfoVMSubnetName,
                        TfoNetworkSecurityGroupId = this.TfoNetworkSecurityGroupId,
                        EnableAcceleratedNetworkingOnTfo = this.EnableAcceleratedNetworkingOnTfo,
                        TfoIPConfigs =
                            new List<IPConfig>
                            {
                                new IPConfig
                                {
                                    StaticIPAddress = this.TfoNicStaticIPAddress,
                                    PublicIpAddressId = this.TfoPublicIPAddressId,
                                    LBBackendAddressPoolIds =
                                        this.TfoLBBackendAddressPoolId?.ToList() ??
                                        new List<string>()
                                }
                            }
                    };

                    break;
            }

            this.WriteObject(nicConfig);
        }
    }
}
