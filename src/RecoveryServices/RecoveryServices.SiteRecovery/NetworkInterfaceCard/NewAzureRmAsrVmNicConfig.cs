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
        ///    Gets or sets the ASR Replication Protected Item.
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
        ///     Gets or sets name of the recovery NIC.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the name of the recovery NIC.")]
        [ValidateNotNullOrEmpty]
        public string RecoveryNicName { get; set; }

        /// <summary>
        ///     Gets or sets name of the recovery NIC resource group name.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the name of the recovery NIC resource group.")]
        [ValidateNotNullOrEmpty]
        public string RecoveryNicResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets whether an existing NIC can be used during failover.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies whether an existing NIC can be used during failover.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ReuseExistingNic { get; set; }

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
        ///     Gets or sets Id of the test failover VM Network.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the ID of the test failover virtual network.")]
        [ValidateNotNullOrEmpty]
        public string TfoVMNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets name of the test failover NIC.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the name of the test failover NIC.")]
        [ValidateNotNullOrEmpty]
        public string TfoNicName { get; set; }

        /// <summary>
        ///     Gets or sets name of the test failover NIC resource group.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies the name of the test failover NIC resource group.")]
        [ValidateNotNullOrEmpty]
        public string TfoNicResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets whether an existing NIC can be reused during test failover.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies whether an existing NIC can be used during test failover.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter TfoReuseExistingNic { get; set; }

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
        ///     Gets or sets the test failover and failover NIC IP configuration details.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Specifies test failover/failover settings of NIC IP configs.")]
        [ValidateNotNull]
        public PSIPConfigInputDetails[] IPConfig { get; set; }

        #endregion Parameters

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            ASRVMNicConfig nicConfig = null;

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

                    if (this.IPConfig != null)
                    {
                        if (!ValidateAndPopulateIPConfigs(vmNic))
                        {
                            return;
                        }
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryVMNetworkId)))
                    {
                        this.RecoveryVMNetworkId =
                            this.ReplicationProtectedItem.SelectedRecoveryAzureNetworkId;
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
                            Utilities.GetMemberName(() => this.TfoVMNetworkId)))
                    {
                        this.TfoVMNetworkId =
                            this.ReplicationProtectedItem.SelectedTfoAzureNetworkId;
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

                    List<PSIPConfigInputDetails> ipConfigList = null;
                    if (this.IPConfig == null || this.IPConfig.ToList().Count == 0)
                    {
                        ipConfigList = vmNic.IpConfigs?.Select(ip => ConvertToPSIPConfig(ip))?.ToList() ?? null;
                    }
                    else if (vmNic.IpConfigs != null)
                    {
                        ipConfigList = this.IPConfig.ToList();
                        // NIC IP config names in lowercase.
                        var inputIPConfigNames = this.IPConfig.Select(ip => ip.IPConfigName.ToLower());

                        foreach (IPConfigDetails ipConfig in vmNic.IpConfigs)
                        {
                            if (inputIPConfigNames.Contains(ipConfig.Name.ToLower()))
                            {
                                continue;
                            }

                            // Defaulting logic for IP configs whose input is not 
                            ipConfigList.Add(ConvertToPSIPConfig(ipConfig));
                        }
                    }

                    nicConfig = new ASRVMNicConfig
                    {
                        NicId = this.NicId,
                        RecoveryVMNetworkId = this.RecoveryVMNetworkId,
                        RecoveryNicName = this.RecoveryNicName,
                        RecoveryNicResourceGroupName = this.RecoveryNicResourceGroupName,
                        ReuseExistingNic = this.ReuseExistingNic,
                        RecoveryNetworkSecurityGroupId = this.RecoveryNetworkSecurityGroupId,
                        EnableAcceleratedNetworkingOnRecovery =
                            this.EnableAcceleratedNetworkingOnRecovery,
                        IPConfigs = ipConfigList,
                        TfoVMNetworkId = this.TfoVMNetworkId,
                        TfoNicName = this.TfoNicName,
                        TfoNicResourceGroupName = this.TfoNicResourceGroupName,
                        TfoReuseExistingNic = this.TfoReuseExistingNic,
                        TfoNetworkSecurityGroupId = this.TfoNetworkSecurityGroupId,
                        EnableAcceleratedNetworkingOnTfo = this.EnableAcceleratedNetworkingOnTfo
                    };

                    break;
            }

            this.WriteObject(nicConfig);
        }

        // validates IP configs and populate values not provided in input from DB NIC entiry.
        // returns false in case of validation error.
        private bool ValidateAndPopulateIPConfigs(ASRVMNicDetails vmNic)
        {
            bool isTfoNetworkRequired = false;
            bool isRecoveryNetworkRequired = false;

            foreach (var ipConfig in this.IPConfig)
            {
                if (!string.IsNullOrEmpty(ipConfig.TfoSubnetName))
                {
                    isTfoNetworkRequired = true;
                }

                if (!string.IsNullOrEmpty(ipConfig.RecoverySubnetName))
                {
                    isRecoveryNetworkRequired = true;
                }

                IPConfigDetails vmNicIPConfig = vmNic.IpConfigs.FirstOrDefault(
                    ip => ip.Name.Equals(
                        ipConfig.IPConfigName, StringComparison.OrdinalIgnoreCase));

                if (vmNicIPConfig == null)
                {
                    this.WriteWarning(
                        string.Format(Resources.IPConfigNotFoundInVMNic,
                        ipConfig.IPConfigName, vmNic.NicId));
                    return false;
                }

                ipConfig.IsPrimary = (bool)vmNicIPConfig.IsPrimary;
                if (string.IsNullOrEmpty(ipConfig.RecoverySubnetName))
                {
                    ipConfig.RecoverySubnetName = vmNicIPConfig.RecoverySubnetName;
                }

                if (ipConfig.RecoveryStaticIPAddress == null)
                {
                    ipConfig.RecoveryStaticIPAddress = vmNicIPConfig.RecoveryStaticIPAddress;
                }

                if (ipConfig.RecoveryPublicIPAddressId == null)
                {
                    ipConfig.RecoveryPublicIPAddressId = vmNicIPConfig.RecoveryPublicIPAddressId;
                }

                if (ipConfig.RecoveryLBBackendAddressPoolIds == null)
                {
                    ipConfig.RecoveryLBBackendAddressPoolIds = vmNicIPConfig.RecoveryLBBackendAddressPoolIds;
                }

                if (string.IsNullOrEmpty(ipConfig.TfoSubnetName))
                {
                    ipConfig.TfoSubnetName = vmNicIPConfig.TfoSubnetName;
                }

                if (ipConfig.TfoStaticIPAddress == null)
                {
                    ipConfig.TfoStaticIPAddress = vmNicIPConfig.TfoStaticIPAddress;
                }

                if (ipConfig.TfoPublicIPAddressId == null)
                {
                    ipConfig.TfoPublicIPAddressId = vmNicIPConfig.TfoPublicIPAddressId;
                }

                if (ipConfig.TfoLBBackendAddressPoolIds == null)
                {
                    ipConfig.TfoLBBackendAddressPoolIds = vmNicIPConfig.TfoLBBackendAddressPoolIds;
                }
            }

            if (isTfoNetworkRequired && string.IsNullOrEmpty(this.TfoVMNetworkId))
            {
                this.WriteWarning(Resources.TfoNetworkInformationMissing);
                return false; ;
            }

            if (isRecoveryNetworkRequired && string.IsNullOrEmpty(this.RecoveryVMNetworkId))
            {
                this.WriteWarning(Resources.TfoNetworkInformationMissing);
                return false; ;
            }

            return true;
        }

        PSIPConfigInputDetails ConvertToPSIPConfig(IPConfigDetails ipConfig)
        {
            return new PSIPConfigInputDetails()
            {
                IPConfigName = ipConfig.Name,
                IsPrimary = (bool)ipConfig.IsPrimary,
                IsSeletedForFailover = (bool)ipConfig.IsSeletedForFailover,
                RecoverySubnetName = ipConfig.RecoverySubnetName,
                RecoveryStaticIPAddress = ipConfig.RecoveryStaticIPAddress,
                RecoveryPublicIPAddressId = ipConfig.RecoveryPublicIPAddressId,
                RecoveryLBBackendAddressPoolIds = ipConfig.RecoveryLBBackendAddressPoolIds,
                TfoSubnetName = ipConfig.TfoSubnetName,
                TfoStaticIPAddress = ipConfig.TfoStaticIPAddress,
                TfoPublicIPAddressId = ipConfig.TfoPublicIPAddressId,
                TfoLBBackendAddressPoolIds = ipConfig.TfoLBBackendAddressPoolIds
            };
        }
    }
}
