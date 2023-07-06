
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------


function New-AzRecoveryServicesReplicationVmNicConfig {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.VMNicConfig])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IReplicationProtectedItem]
        # Replication protected item Object.
        ${ReplicatedProtectedItem},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Whether the NIC has accelerated networking enabled.
        ${EnableAcceleratedNetworkingOnRecovery},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Whether the test NIC has accelerated networking enabled.
        ${EnableAcceleratedNetworkingOnTfo},

        [Parameter()]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IIPConfigInputDetails]
        # The IP configurations to be used by NIC during test failover and failover.
        ${IPConfig},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The nic Id.
        ${NicId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The id of the NSG associated with the NIC.
        ${RecoveryNetworkSecurityGroupId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The name of the NIC to be used when creating target NICs.
        ${RecoveryNicName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The resource group of the NIC to be used when creating target NICs.
        ${RecoveryNicResourceGroupName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # A value indicating whether an existing NIC is allowed to be reused during failover subject to availability.
        ${ReuseExistingNic},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The ID of the recovery virtual network.
        ${RecoveryVMNetworkId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The ID of the test failover virtual network.
        ${TfoVMNetworkId},
        
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # Selection type for failover.
        ${SelectionType},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # Target NIC name.
        ${TargetNicName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The NSG to be used by NIC during test failover.
        ${TfoNetworkSecurityGroupId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The name of the NIC to be used when creating target NICs in TFO.
        ${TfoNicName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The resource group of the NIC to be used when creating target NICs in TFO.
        ${TfoNicResourceGroupName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # A value indicating whether an existing NIC is allowed to be reused during test failover subject to availability.
        ${TfoReuseExistingNic}
    )

    process {
        try {
            $nicConfig = $null

            $ProviderSpecificDetails = $ReplicatedProtectedItem.ProviderSpecificDetail

            if($ProviderSpecificDetails.InstanceType -ne "A2A") {
                throw "Unsupported replication provider for vm nic config"
            }

            $VmNicDetailsList = $ProviderSpecificDetails.VmNic
            
            $vmNic = $VmNicDetailsList | ForEach-Object {
                if($_.NicId -eq $NicId){
                    return $_
                }
            }
            
            if($vmNic -eq $null) {
                throw "Nic Not found in the VM"
            }
            
            if($IPConfig -ne $null) {
                $IPConfig = ValidateAndPopulateIPConfigs -VmNic $vmNic -IPConfig $IPConfig -RecoveryVMNetworkId $RecoveryVMNetworkId -TfoVMNetworkId $TfoVMNetworkId
            }
            
            if (-not $PSBoundParameters.ContainsKey('RecoveryVMNetworkId')) {
                $RecoveryVMNetworkId = $ProviderSpecificDetails.SelectedRecoveryAzureNetworkId
            }
            
            if (-not $PSBoundParameters.ContainsKey('RecoveryNetworkSecurityGroupId') -and -not [string]::IsNullOrEmpty($vmNic.RecoveryNetworkSecurityGroupId)) {
                $RecoveryNetworkSecurityGroupId = $vmNic.RecoveryNetworkSecurityGroupId
            }
            
            if (-not $PSBoundParameters.ContainsKey('EnableAcceleratedNetworkingOnRecovery')) {
                $EnableAcceleratedNetworkingOnRecovery = $vmNic.EnableAcceleratedNetworkingOnRecovery -or $false
            }
            
            if (-not $PSBoundParameters.ContainsKey('TfoVMNetworkId') -and -not [string]::IsNullOrEmpty($ProviderSpecificDetails.SelectedTfoAzureNetworkId)) {
                $TfoVMNetworkId = $ProviderSpecificDetails.SelectedTfoAzureNetworkId
            }
            
            if (-not $PSBoundParameters.ContainsKey('TfoNetworkSecurityGroupId') -and -not [string]::IsNullOrEmpty($vmNic.TfoNetworkSecurityGroupId)) {
                $TfoNetworkSecurityGroupId = $vmNic.TfoNetworkSecurityGroupId
            }
            
            if (-not $PSBoundParameters.ContainsKey('EnableAcceleratedNetworkingOnTfo')) {
                $EnableAcceleratedNetworkingOnTfo = $vmNic.EnableAcceleratedNetworkingOnTfo -or $false
            }
            
            $ipConfigList = @()
            if($IPConfig -eq $null -or $IPConfig.Count -eq 0) {
                $ipConfigList = $vmNic.IPConfig | ForEach-Object { ConvertToPSIPConfig $_ } | ForEach-Object { $_ } | Select-Object -Unique
            }
            elseif($vmNic.IPConfig -ne $null) {
                $ipConfigList = $IPConfig
            
                $inputIPConfigNames = $IPConfig | ForEach-Object { $_.IPConfigName.ToLower() }
            
                foreach ($ipconfig in $vmNic.IPConfig) {
                    if ($inputIPConfigNames -contains $ipconfig.Name.ToLower()) {
                        continue
                    }
            
                    $ipConfigList += ConvertToPSIPConfig $ipconfig
                }
            }

            $nicConfig = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.VMNicConfig]::new()
            $nicConfig.EnableAcceleratedNetworkingOnRecovery = $EnableAcceleratedNetworkingOnRecovery
            $nicConfig.EnableAcceleratedNetworkingOnTfo = $EnableAcceleratedNetworkingOnTfo
            $nicConfig.IPConfig = $ipConfigList
            $nicConfig.NicId = $NicId
            $nicConfig.RecoveryNetworkSecurityGroupId = $RecoveryNetworkSecurityGroupId
            $nicConfig.RecoveryNicName = $RecoveryNicName
            $nicConfig.RecoveryNicResourceGroupName = $RecoveryNicResourceGroupName
            $nicConfig.ReuseExistingNic = $ReuseExistingNic
            $nicConfig.RecoveryVMNetworkId = $RecoveryVMNetworkId
            $nicConfig.TfoVMNetworkId = $TfoVMNetworkId
            $nicConfig.SelectionType = $SelectionType
            $nicConfig.TargetNicName = $TargetNicName
            $nicConfig.TfoNetworkSecurityGroupId = $TfoNetworkSecurityGroupId
            $nicConfig.TfoNicName = $TfoNicName
            $nicConfig.TfoNicResourceGroupName = $TfoNicResourceGroupName
            $nicConfig.TfoReuseExistingNic = $TfoReuseExistingNic

            return $nicConfig
        } catch {
            throw
        }
    }
}
